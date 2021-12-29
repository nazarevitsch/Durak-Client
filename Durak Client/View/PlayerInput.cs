using System;
using System.Collections.Generic;
using Durak_Client.DataType;

namespace Durak_Client.View
{
    public class PlayerInput
    {
        public static List<int> GetSelectedCards()
        {
            string? userInput = Console.ReadLine();
            List<int> choice = new();
            if (userInput != null)
            {
                string[] array = userInput.Split(' ');
                foreach (var str in array)
                {
                    choice.Add(Int32.Parse(str));
                }
            }

            return choice;
        }
        
        public static PlayerAction GetAction()
        {
            var userInput = Console.In.ReadLine();
            if (userInput != null)
            {
                return (PlayerAction) Int32.Parse(userInput);
            }

            throw new Exception("Aaaaaaaaaaaaaaaa");
        }
    }
}