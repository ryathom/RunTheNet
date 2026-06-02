namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface IStaticEffect
    {
        public void Apply(Card subject);
        public IStaticEffect Copy();
    }
}