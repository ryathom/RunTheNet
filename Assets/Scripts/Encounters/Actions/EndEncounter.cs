using System.Collections;
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
                EncounterUIManager.Instance.RewardsPopUp.SetRewards(credits);

                RunManager.Instance.GiveRewards();
            }

            // EncounterManager.Instance.EndEncounter();
            EncounterManager.Instance.StopActions();
            return null;
        }
    }
}