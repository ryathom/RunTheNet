namespace ryathom.RunTheNet.Encounters.Cards
{
    public class Card
    {
        public CardSO CardSO {get; protected set;}

        public CardContainer Container {get; private set;}

        public Card(CardSO cardSO)
        {
            this.CardSO = cardSO;
        }

        public void SetContainer(CardContainer container)
        {
            Container = container;
        }
    }
}