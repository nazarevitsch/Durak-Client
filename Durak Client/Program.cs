using System;
using Durak_Client;
using Durak_Client.Networking;

class Program
{
    private static int port = 8001;
    private static string address = "127.0.0.1";
    static void Main(string[] args)
    {
        var client = new Client(address, port);
        var game = new Game(client);
        game.StartGame();
    }
}