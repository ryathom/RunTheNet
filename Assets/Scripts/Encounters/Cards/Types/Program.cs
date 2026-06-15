namespace ryathom.RunTheNet.Encounters.Cards
{
    public class Program : Card
    {
        public ProgramSO programSO;
        public ICost Cost;
        public int Strength;

        public Program(CardSO cardSO) : base(cardSO)
        {
            programSO = (ProgramSO)cardSO;
            Cost = programSO.Cost.Copy();
            Strength = programSO.Strength;
        }

        public void ResetStrength()
        {
            Strength = programSO.Strength;
        }

    }
}