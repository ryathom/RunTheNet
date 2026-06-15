namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface ICondition
    {
        public bool Evaluate(Card source);
        public ICondition Copy();
    }
}