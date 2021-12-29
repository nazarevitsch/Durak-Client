namespace Durak_Client.DataType
{
    public class CardCouplet
    {
        public CardType FirstCard { get; set; }
        public CardType? BeatCard { get; set; }

        public override string ToString()
        {
            return $"First card: {FirstCard} <= Beat card: {BeatCard} ";
        }
    }
}