using System.Collections;
using ryathom.RunTheNet.Encounters.Actions;

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

            yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(card, EncounterManager.Instance.Server));
            
            card.Activate();
        }

        public IEffect Copy()
        {
            return new InstallFromReserves();
        }
    }
}