using System.Collections;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class EndEncounter : IAction
    {
        public IEnumerator Execute()
        {
            GameManager.Instance.LoadScene("RunScene");

            return null;
        }
    }
}