using System.Collections;
using ryathom.RunTheNet.Encounters.Player;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class ClickToDrawCard : IAction
    {
        private Runner runner;

        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;

            if (runner.Clicks <= 0) yield break;
            if (runner.Repository.Cards.Count <= 0) yield break;

            runner.SpendClicks(1);

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new DrawCard());
        }
    }
}