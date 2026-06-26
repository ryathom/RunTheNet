using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class RepoBrowser : MonoBehaviour
    {
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private Transform cardPanel;
        private List<CardContainer> containers;

        private void Awake()
        {
            containers = new();
        }

        public void ShowRepo()
        {
            Debug.Log(RunManager.Instance);
            Debug.Log(RunManager.Instance.Programs);
            Debug.Log(RunManager.Instance.Programs.Count);

            if (RunManager.Instance.Programs == null) return;

            ShowCards(RunManager.Instance.Programs);
        }

        public void ShowCards(List<Card> cards)
        {
            ClearCards();

            foreach (Card card in cards)
            {
                CardContainer container = Instantiate(cardPrefab, cardPanel.transform);
                container.SetCard(card);
                container.gameObject.SetActive(true);
                containers.Add(container);
            }
        }

        public void ClearCards()
        {

            if (containers.Count == 0) return;

            foreach (CardContainer container in containers)
            {
                Destroy(container.gameObject);
            }

            containers.Clear();
        }

        public void ExitBrowser()
        {
            this.gameObject.SetActive(false);
        }
    }
}