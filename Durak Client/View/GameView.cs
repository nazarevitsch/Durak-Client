using System;
using Durak_Client.Networking;

namespace Durak_Client.View
{
    public class GameView
    {
        public static void ShowMessage(string str)
        {
            Console.WriteLine(str);
        }
        
        public static void ShowGameState(Command state)
        {
            Console.WriteLine($"Cards in deck:{state.DeckCardsLeft}");
            Console.WriteLine($"Trump:{state.BottomCard.rank}");
            Console.WriteLine($"Bottom card:{state.BottomCard}");
            if ((state.CardCouplets?.Count ?? 0)== 0) return;
            
            var i = 0;
            foreach (var couplet in state.CardCouplets)
            {
                Console.WriteLine($"{i}:{couplet}");
                i++;
            }
        }

        public static void ShowPlayerState(Command player)
        {
            Console.WriteLine("Your cards:");

            if (player.Cards.Count == 0) return;
            
            var i = 0;
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"{i}:{card}");
                i++;
            }
            Console.Write("");
        }

        public static void ShowActions()
        {
            Console.WriteLine($"Actions:");
            Console.WriteLine($"0:{CommandCodes.ThrowCards}");
            Console.WriteLine($"1:{CommandCodes.BeatCards}");
            Console.WriteLine($"2:{CommandCodes.Pass}");
            Console.WriteLine($"3:{CommandCodes.TakeCards}");
        }
    }
}