namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface ICondition
    {
        public bool Evaluate();
        public ICondition Copy();
    }
}