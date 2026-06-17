using System.Collections;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [System.Serializable]
    public class SpawnIce : IEffect
    {
        public IceSO IceSO;

        public SpawnIce() {}

        public SpawnIce(IceSO iceSO)
        {
            IceSO = iceSO;
        }

        public IEnumerator Execute(Card source)
        {
            Ice Ice = new(IceSO);

            EncounterManager.Instance.InstantiateCardContainer(EncounterManager.Instance.ServerView.transform, Ice);
            EncounterManager.Instance.Server.AddCard(Ice);

            return null;
        }

        public IEffect Copy()
        {
            return new SpawnIce(IceSO);
        }
    }
}