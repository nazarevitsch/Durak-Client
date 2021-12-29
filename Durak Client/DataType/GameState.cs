using System.Collections.Generic;

namespace Durak_Client.DataType
{
    public class GameState
    {
        public DeckType deckType;
        public List<CardCouplet> fieldState = new();

        public HashSet<Rank> allowedRanks = new();
    }
}