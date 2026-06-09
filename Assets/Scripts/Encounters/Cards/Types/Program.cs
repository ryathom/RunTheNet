namespace ryathom.RunTheNet.Encounters.Cards
{
    public class Program : Card
    {
        public ProgramSO programSO;
        public ICost Cost;

        public Program(CardSO cardSO) : base(cardSO)
        {
            programSO = (ProgramSO)cardSO;
            Cost = programSO.Cost.Copy();
        }

    }
}