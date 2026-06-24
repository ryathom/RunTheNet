using System.Collections;
using UnityEngine;
using ryathom.RunTheNet.Encounters.Player;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class DrawCard : IAction
    {
        private Runner runner;

        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;
            if (runner.Repository.Cards.Count <= 0)
            {
                if (runner.Trash.Cards.Count > 0)
                {
                    yield return GarbageCollection();
                    yield return new WaitForSeconds(0.5f);
                } else
                {
                    yield break;
                }
            }
            
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(runner.Repository.Cards[0], runner.Hand));
        }

        public IEnumerator GarbageCollection()
        {
            while(EncounterManager.Instance.Runner.Trash.Cards.Count > 0)
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(EncounterManager.Instance.Runner.Trash.Cards[0], EncounterManager.Instance.Runner.Repository));
            }            

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ShuffleRepo());
        }
    }
}