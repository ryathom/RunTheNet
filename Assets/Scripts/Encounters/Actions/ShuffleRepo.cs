using System.Collections;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ShuffleRepo : IAction
    {
        public IEnumerator Execute()
        {
            EncounterManager.Instance.Runner.Repository.Shuffle();

            return null;
        }
    }
}