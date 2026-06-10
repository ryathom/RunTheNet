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
            GameManager.Instance.LoadScene("RunScene");

            return null;
        }
    }
}