using System.Collections.Generic;

namespace Durak_Client.DataType
{
    public class Player
    {
        public int id;
        public List<CardType> hand = new();
    }
}