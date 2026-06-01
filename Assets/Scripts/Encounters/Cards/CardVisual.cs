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
            type.text = card.CardSO.cardType.ToString();
            text.text = card.CardSO.cardText;
        }
    }
}