using System.Collections;
using ryathom.RunTheNet.Encounters.System;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class DrawCard : IAction
    {
        public IEnumerator Execute()
        {
            EncounterManager.Instance.Runner.DrawCard();
            return null;
        }
    }
}