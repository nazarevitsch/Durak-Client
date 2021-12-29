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
            // Recieve Mesages
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