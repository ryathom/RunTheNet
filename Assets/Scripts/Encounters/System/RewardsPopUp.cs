using ryathom.RunTheNet.Encounters.Cards;
using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters
{
    public class RewardsPopUp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private Transform cardRewardsContainer;
        // [SerializeField] private CardContainer cardPrefab;

        public void SetRewards(int credits)
        {
            creditsText.text = "Credits: " + credits.ToString();
        }
    }
}