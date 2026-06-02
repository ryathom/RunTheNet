using System.Collections;
using UnityEngine;
using ryathom.RunTheNet.Encounters.Player;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class DrawCard : IAction
    {
        private Runner runner;

        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;
            if (runner.Repository.Cards.Count <= 0) yield break;
            
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(runner.Repository.Cards[0], runner.Hand));
        }
    }
}