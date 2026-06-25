using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Player;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class NetDamage : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            Runner runner = EncounterManager.Instance.Runner;
            int count = runner.Hand.Cards.Count;

            if (count == 0)
            {
                Debug.Log("Runner flatlined");
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter(success: false));
            } else
            {
                int index = Random.Range(0, count);
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(runner.Hand.Cards[index]));
            }
        }

        public IEffect Copy()
        {
            return new NetDamage();
        }
    }
}