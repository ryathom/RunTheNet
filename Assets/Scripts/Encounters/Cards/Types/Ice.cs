namespace ryathom.RunTheNet.Encounters.Cards
{
    public class Ice : Card
    {
        public IceSO IceSO {get; private set;}
        public int Strength {get; private set;}

        public Ice(CardSO cardSO) : base(cardSO)
        {
            IceSO = (IceSO)cardSO;
            Strength = IceSO.Strength;
        }
    }


}