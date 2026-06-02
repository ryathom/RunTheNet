using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class OnEndTurn : ITrigger
    {
        public bool HasTriggered(IAction action, Card source)
        {
            if (action is EndTurn) return true;

            return false;       
        }

        public ITrigger Copy()
        {
            return new OnEndTurn();
        }
    }
}