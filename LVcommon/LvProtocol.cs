using System.Net.Sockets;

namespace LVCommon
{
    public class LvProtocol
    {


        public static byte[] ConvertValue(byte[] valueBuffer)
        {
            int length = valueBuffer.Length;
            byte[] lengthBuffer = BitConverter.GetBytes(length);
            byte[] resultBuffer = new byte[lengthBuffer.Length+valueBuffer.Length];

            Array.Copy(lengthBuffer, 0, resultBuffer, 0, 4);
            Array.Copy(valueBuffer, 0, resultBuffer, 4, valueBuffer.Length);

            return resultBuffer;
        }


        public static async Task<(byte[], bool success)> ReadValueAsync(NetworkStream stream)
        {
            var r = await ReadExatlyAsync(stream, 4);

            if (!r.success) return (r.buffer, false);

            int valueLength = BitConverter.ToInt32(r.buffer, 0);

            r = await ReadExatlyAsync(stream, valueLength);

            if(!r.success) return (r.buffer, false);

            return (r.buffer, true);
        }


        private static async Task<(bool success , byte[] buffer)> ReadExatlyAsync(NetworkStream stream, int length)
        {
            int recevied = 0;
            byte[] buffer = new byte[length];

            while (recevied < length)
            {
                int readLength =  await stream.ReadAsync(buffer.AsMemory(recevied, length- recevied));
                if(readLength == 0) return (false,buffer);
                recevied += readLength;
            }

            return (true,buffer);
        }
    }
}
