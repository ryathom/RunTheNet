using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class NextPhase : IAction
    {
        public IEnumerator Execute()
        {
            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            info.CurrentPhase.Exit();
            info.PreviousPhase = info.CurrentPhase;
            info.CurrentPhase = info.CurrentPhase.NextPhase();
            info.CurrentPhase.Enter();

            Debug.Log(info.CurrentPhase.GetType().Name);

            return null;
        }
    }
}