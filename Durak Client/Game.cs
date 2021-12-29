using System;
using Durak_Client.Networking;

namespace Durak_Client
{
    public class Game
    {
        
        private int player_id = -1;
        private Client client;
        public Game(Client _client)
        {
            client = _client;
        }

        public void StartGame()
        {
            try
            {
                client.Connect();
                client.SendCommandToServer(new Command
                {
                    Code = CommandCodes.ConnectToSession
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}