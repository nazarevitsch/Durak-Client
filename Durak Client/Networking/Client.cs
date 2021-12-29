using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using Durak_Client.DataType;

namespace Durak_Client.Networking
{
    public class Client
    {
        private static int _port = 8001;
        private static string _address = "127.0.0.1";
        private TcpClient _client;
        private Thread _messageThread;
        private Player _player;
        public NetworkStream Stream { get; private set; }
        public delegate void GotCommand(Command cmd);

        public event GotCommand OnGotCommand;

        public Client(string address, int port)
        {
            _port = port;
            _address = address;
        }

        public void Connect()
        {
            _client = new TcpClient(AddressFamily.InterNetwork);
            _client.Connect(_address, _port);
            Stream = _client.GetStream();
            StartMessageListen();
        }
        
        private void StartMessageListen()
        {
            _messageThread = new Thread(ReceiveMessage);
            _messageThread.Start();
        }
        
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[120];
                    StringBuilder builder = new();
                    int bytes;
                    do
                    {
                        bytes = Stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (Stream.DataAvailable);

                    string message = builder.ToString();
                    try
                    {
                        var cmd = JsonSerializer.Deserialize<Command>(message);
                        OnGotCommand?.Invoke(cmd);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something wrong on command parse.");
                        Console.WriteLine(e);
                    }
                }
                catch
                {
                    Console.WriteLine("Connection was interrupted.");
                    _messageThread.Join();
                    break;
                }
            }
        }
        
        public void SendCommandToServer(Command cmd)
        {
            string message = JsonSerializer.Serialize(cmd);
            byte[] data = Encoding.Unicode.GetBytes(message);
            Stream.Flush();
            Stream.Write(data, 0, data.Length);
        }
    }
}