using UnityEngine;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class TrashSelf : IEffect
    {
        public void Execute()
        {
            Debug.Log("Should trash self");
            // EncounterManager.Instance.Actions.AddAction(new ChangeZone())
        }

        public IEffect Copy()
        {
            return new TrashSelf();
        }
    }
}