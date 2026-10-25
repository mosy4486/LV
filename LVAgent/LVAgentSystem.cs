using System;
using System.Collections.Generic;
using System.Text;
using LVCommon;
using System.Net.Sockets;
using System.Net;
namespace LVAgent
{
    public class LVAgentSystem
    {
        private CancellationTokenSource? source;
        public TcpClient? client { get; private set; }
        public float sendDistanceSecond;

        public LVAgentSystem()
        {
            sendDistanceSecond = 0.05f;
        }
        public async Task Start()
        {
            if (source != null||client!=null) return;

            source = new CancellationTokenSource();
            client = new();
            while (!source.Token.IsCancellationRequested)
            {
                try
                {
                    while (!source.Token.IsCancellationRequested)
                    {
                        await client.ConnectAsync(LVDefault.cIP,LVDefault.port, source.Token);

                        NetworkStream stream = client.GetStream();
                        while (!source.Token.IsCancellationRequested)
                        {
                            byte[] captureBuffer = ScreenManager.Capture();
                            byte[] writeBuffer = LvProtocol.ConvertValue(captureBuffer);
                            try
                            {
                                await stream.WriteAsync(writeBuffer, source.Token);
                            }
                            catch (IOException) { }
                            catch (SocketException) { }

                            await Task.Delay(Convert.ToInt32((sendDistanceSecond * 1000f)), source.Token);
                        }
                    }
                }
                catch (SocketException)
                {
                    await Task.Delay(1000);
                }
            }
                
        }



        public void Stop()
        {
            if (source == null||source.IsCancellationRequested||client==null) return;

            source.Cancel();
            client.Close();

            client = null;
            source = null;
        }
    }
}
