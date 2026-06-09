using UnityEngine;
using ryathom.RunTheNet.Encounters.Actions;
using System.Collections;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashSelf : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new TrashCard(source));
        }

        public IEffect Copy()
        {
            return new TrashSelf();
        }
    }
}