using System.Collections;

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
            EncounterManager.Instance.EndEncounter();

            return null;
        }
    }
}