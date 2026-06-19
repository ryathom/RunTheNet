using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Encounters.Player;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class DrawCardEffect : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new DrawCard());
        }

        public IEffect Copy()
        {
            return new DrawCardEffect();
        }
    }

    [System.Serializable]
    public class RandomDiscard : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            Runner runner = EncounterManager.Instance.Runner;
            int count = runner.Hand.Cards.Count;

            if (count == 0) yield break;

            int index = Random.Range(0, count);

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(runner.Hand.Cards[index]));
        }

        public IEffect Copy()
        {
            return new RandomDiscard();
        }
    }
}