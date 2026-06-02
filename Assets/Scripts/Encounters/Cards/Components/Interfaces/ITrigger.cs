using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public interface ITrigger
    {
        public bool HasTriggered(IAction action, Card source);
        public ITrigger Copy();
    }
}