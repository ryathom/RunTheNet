namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface IEffect
    {
        public void Execute();
        public IEffect Copy();
    }

    public interface ITargetingEffect
    {
        public List<Card> GetValidTargets(Card source);
        public void SetTarget(Card target);
        public bool TargetSelected();
    }
}