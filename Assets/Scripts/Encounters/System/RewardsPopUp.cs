using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Run;
using TMPro;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters
{
    public class RewardsPopUp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;
        [SerializeField] private Transform cardRewardsContainer;
        [SerializeField] private CardContainer cardPrefab;

        public void SetRewards(int credits, List<ProgramSO> cards)
        {
            creditsText.text = "Credits: " + credits.ToString();

            foreach (ProgramSO cardSO in cards)
            {
                Program card = new(cardSO);
                CardContainer container = Instantiate(cardPrefab, cardRewardsContainer.transform);

                container.SetCard(card);
                container.OnClickCard += ChooseReward;
                container.gameObject.SetActive(true);
            }
        }

        public void ChooseReward(Card card)
        {
            RunManager.Instance.ChooseReward(card);
            EncounterManager.Instance.EndEncounter();
        }
    }
}