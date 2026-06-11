using System.Collections;
using ryathom.RunTheNet.Run;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class EndEncounter : IAction
    {
        public bool Success {get; private set;}

        public EndEncounter() {}

        public EndEncounter(bool success)
        {
            Success = success;
        }

        public IEnumerator Execute()
        {
            if (Success == true)
            {
                RunManager.Instance.GiveRewards();
            }

            EncounterManager.Instance.EndEncounter();

            return null;
        }
    }
}