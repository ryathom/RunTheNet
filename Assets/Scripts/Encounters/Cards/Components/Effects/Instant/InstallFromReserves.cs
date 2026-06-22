using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class InstallFromReserves : IEffect
    {
        public InstallFromReserves() {}

        public IEnumerator Execute(Card source)
        {
            if (EncounterManager.Instance.Reserves.Cards.Count == 0) yield break;

            Card card = EncounterManager.Instance.Reserves.Cards[0];

            if (EncounterManager.Instance.Server.GetFirstEmptyIndex() == -1)
            {
                Debug.Log("Server overflow!");
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter(success: false));
            }

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(card, EncounterManager.Instance.Server));
            
            card.Activate();
        }

        public IEffect Copy()
        {
            return new InstallFromReserves();
        }
    }
}