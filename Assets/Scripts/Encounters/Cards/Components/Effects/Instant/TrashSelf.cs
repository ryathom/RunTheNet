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
            Debug.Log("Should trash self " + source.Name);

            return null;
            // EncounterManager.Instance.Actions.AddAction(new ChangeZone())
        }

        public IEffect Copy()
        {
            return new TrashSelf();
        }
    }
}