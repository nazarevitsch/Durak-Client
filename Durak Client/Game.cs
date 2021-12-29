using System;
using System.Collections.Generic;
using Durak_Client.DataType;
using Durak_Client.Networking;
using Durak_Client.View;

namespace Durak_Client
{
    public class Game
    {
        
        private int player_id = -1;
        private readonly GameView view = new();
        private Client client;
        private Command command = new ();
        public void ProcessCommand(Command cmd)
        {
            if (cmd.Code == CommandCodes.ConnectedToSession)
            {
                player_id = cmd.PlayerId;
                return;
            }
            if (cmd.Code == CommandCodes.SessionCreated)
            {
                player_id = cmd.PlayerId;
                return;
            }
            
            GameView.ShowMessage($"Oponent cards:{cmd.EnemyPlayerCardsLeft}");

            if (cmd.PlayerId == player_id)
            {
                GameView.ShowPlayerState(cmd);
                GameView.ShowActions();
            }

            if (cmd.Code == CommandCodes.YouTurn)
            {

            }
        }

        public void StartGame()
        {
            client.OnGotCommand += ProcessCommand;
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