using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardVisual : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI type;
        [SerializeField] private TextMeshProUGUI text;

        private Card card;

        public void SetCard(Card card)
        {
            this.card = card;
            
            UpdateVisuals();
        }

        public void UpdateVisuals()
        {
            background.sprite = card.CardSO.BackgroundImage;
            title.text = card.CardSO.name;
            text.text = card.CardSO.cardText;
            
            SetTypeText();
        }

        public void SetTypeText()
        {
            if (card.CardSO is ProgramSO)
            {
                type.text = "Program";
            } else if (card.CardSO is IceSO)
            {
                type.text = "ICE";
            } else if (card.CardSO is ServerAssetSO)
            {
                type.text = "Asset";
            }
        }
    }
}