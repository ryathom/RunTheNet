using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class SuccessfulAccess : IEffect
    {
        public IEnumerator Execute(Card source)
        {
            Debug.Log("Successful access");
            yield return new WaitForSeconds(1f);
            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter(success: true));
        }

        public IEffect Copy()
        {
            return new SuccessfulAccess();
        }
    }
}