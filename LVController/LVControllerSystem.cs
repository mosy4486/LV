using LVCommon;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LVController
{
    public class LVControllerSystem
    {
        public TcpListener? listener { get; private set; }
        private CancellationTokenSource? source;

        private TcpClient? client;

        public bool isRunning { get; private set; } = false;

        public event Action<byte[]>? ScreenReceived;
        public async Task Start()
        {
            if (listener != null || source != null || isRunning)
            {
                return;
            }

            isRunning = true;

            source = new CancellationTokenSource();

            listener = new TcpListener(IPAddress.Any, LVDefault.port);

            listener.Start();

            while (!source.Token.IsCancellationRequested)
            {
                client = await listener.AcceptTcpClientAsync(source.Token);

                try
                {
                    NetworkStream stream = client.GetStream();

                    while (!source.Token.IsCancellationRequested)
                    {
                        var result = await LvProtocol.ReadValueAsync(client.GetStream());
                        if (!result.success) break;

                        ScreenReceived?.Invoke(result.Item1);
                    }

                }
                catch (IOException)
                {
                }
                catch (SocketException)
                {
                }
            }
            Stop();
        }

        public void Stop()
        {
            if (listener == null | source == null||!isRunning) return;

            isRunning=false;

            listener.Stop();
            listener.Dispose();
            listener = null;

            source.Cancel();
        }

    }
}
