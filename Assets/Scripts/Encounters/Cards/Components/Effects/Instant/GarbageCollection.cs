using ryathom.RunTheNet.Encounters.Actions;
using System.Collections;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class GarbageCollection : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            foreach(Card card in EncounterManager.Instance.Runner.Trash.Cards)
            {
                if (card is Program)
                {
                    EncounterManager.Instance.Actions.AddAction(new ChangeZone(card, EncounterManager.Instance.Runner.Repository));
                }
            }

            EncounterManager.Instance.Actions.AddAction(new ShuffleRepo());

            yield return null;
        }

        public IEffect Copy()
        {
            return new GarbageCollection();
        }
    }
}