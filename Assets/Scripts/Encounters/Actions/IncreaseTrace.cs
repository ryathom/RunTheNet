using System.Collections;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class IncreaseTrace : IAction
    {
        public int Value {get; private set;}

        public IncreaseTrace(int value)
        {
            Value = value;
        }

        public IEnumerator Execute()
        {
            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            info.Trace += Value;

            return null;
        }
    }
}