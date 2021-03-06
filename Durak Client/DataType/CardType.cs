namespace Durak_Client.DataType
{
    public class CardType
    {
        public Rank rank;
        public Suit suit;

        public CardType(Rank _rank, Suit _suit)
        {
            rank = _rank;
            suit = _suit;
        }
        
        public override string ToString()
        {
            return $"Card(R:{Rank.ToString()};S:{Suit.ToString()})";
        }
    }
}