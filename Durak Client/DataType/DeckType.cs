namespace Durak_Client.DataType
{
    public class DeckType
    {
        public static int deckSize = 32;
        public int cardAmout { get; set; }
        public Suit trump { get; set; }
        public CardType bottomCard { get; set; }
        public DeckType()
        {
            
        }
    }
}