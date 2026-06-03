using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardSetter : MonoBehaviour
    {
        [SerializeField] private CardSO cardSO;

        public void Start()
        {
            InstantiateCard();
        }

        [ContextMenu("Update Card")]
        public void InstantiateCard()
        {
            CardContainer container = GetComponent<CardContainer>();

            Card card = null;

            if (cardSO is IceSO iceSO)
            {
                card = new Ice(iceSO);
            } else if (cardSO is ServerAssetSO assetSO)
            {
                card = new ServerAsset(assetSO);
            } else
            {
                Debug.LogError("Unrecognised card type " + cardSO);
            }

            if (card != null)
            {
                container.SetCard(card);
            }
        }
    }
}