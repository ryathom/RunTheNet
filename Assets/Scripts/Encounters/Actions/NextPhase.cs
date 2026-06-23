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
            info.CurrentPhase = info.CurrentPhase.NextPhase();
            info.CurrentPhase.Enter();

            if (info.CurrentPhase is RunnerStartPhase)
            {
                EncounterUIManager.Instance.ShowText("Turn " + info.CurrentTurn);
                yield return new WaitForSeconds(0.5f);

                EncounterUIManager.Instance.ShowText("");
            }
        }
    }
}