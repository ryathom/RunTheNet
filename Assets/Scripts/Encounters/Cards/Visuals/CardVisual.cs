using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardVisual : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite hardwareSprite;
        [SerializeField] private Sprite programSprite;
        [SerializeField] private Sprite iceSprite;
        [SerializeField] private Sprite assetSprite;

        [Header("Components")]
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI type;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject costField;
        [SerializeField] private TextMeshProUGUI costValue;

        private Card card;

        public void SetCard(Card card)
        {
            this.card = card;
            
            UpdateVisuals();
        }

        public void UpdateVisuals()
        {
            title.text = card.CardSO.name;
            text.text = card.CardSO.cardText;
            
            SetTypeText();
            SetBackground();
            SetActive();
            SetCost();
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
            } else if (card.CardSO is HardwareSO)
            {
                type.text = "Hardware";
            }
        }

        public void SetBackground()
        {
            if (card.CardSO is IceSO)
            {
                background.sprite = iceSprite;
            } else if (card.CardSO is ServerAssetSO)
            {
                background.sprite = assetSprite;
            } else if (card.CardSO is ProgramSO)
            {
                background.sprite = programSprite;
            } else if (card.CardSO is HardwareSO)
            {
                background.sprite = hardwareSprite;
            } else
            {
                Debug.LogError("Unrecognised CardSO");
            }
        }

        public void SetActive()
        {
            if (card.Active)
            {
                background.color = Color.white;
            } else
            {
                background.color = Color.gray;
            }
        }

        public void SetCost()
        {
            if (card is Program program)
            {
                costField.SetActive(true);
                costValue.text = (program.Cost is ClickCost clickCost) ? clickCost.Clicks.ToString() : "0";
            } else
            {
                costField.SetActive(false);
            }
        }
    }
}