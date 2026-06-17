using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class OnCorpTurn : ITrigger
    {
        public bool HasTriggered(IAction action, Card source)
        {
            if (action is NextPhase)
            {
                EncounterInfo info = EncounterManager.Instance.EncounterInfo;
                
                if (info.CurrentPhase is CorpPhase)
                {
                    return true;
                }
            }

            return false;       
        }

        public ITrigger Copy()
        {
            return new OnCorpTurn();
        }
    }

    [System.Serializable]
    public class OnEndCorpTurn : ITrigger
    {
        public bool HasTriggered(IAction action, Card source)
        {
            if (action is EndCorpTurn)
            {
                return true;
            }

            return false;       
        }

        public ITrigger Copy()
        {
            return new OnEndCorpTurn();
        }
    }
}