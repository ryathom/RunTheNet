using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class OnInstall : ITrigger
    {
        public bool HasTriggered(IAction action, Card source)
        {
            if (action is InstallProgram install && install.Program == source)
            {
                return true;
            }

            return false;
        }

        public ITrigger Copy()
        {
            return new OnInstall();
        }
    }
}