using System.Collections;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public interface IAction
    {
        public IEnumerator Execute();
    }
}