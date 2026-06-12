using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Run;
using UnityEngine;

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
            if (Success == true)
            {
                EncounterUIManager.Instance.ShowRewardsPopUp(true);

                int credits = RunManager.Instance.CurrentEncounter.CreditsReward;
                List<ProgramSO> programs = RunManager.Instance.CurrentEncounter.ProgramRewards;
                EncounterUIManager.Instance.RewardsPopUp.SetRewards(credits, programs);

                RunManager.Instance.GiveRewards();
            }

            EncounterManager.Instance.StopActions();
            return null;
        }
    }
}