using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.System
{
    public class EncounterManager : MonoBehaviour
    {
        [SerializeField] private List<CardSO> tempPlayerDecklist;
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private Canvas cardCanvas;

        private List<Card> programs;

        private Repository repository;
        private Hand hand;
        private Rig rig;

        [SerializeField] private HandView handView;
        [SerializeField] private RigView rigView;

        public void Start()
        {
            programs = new();
            SetupPrograms();
            repository = new(programs);
            hand = new();
            rig = new();

            handView.SetZone(hand);
            rigView.SetZone(rig);

            handView.OnClickCardInHand += AddCardToRig;
        }

        private void SetupPrograms()
        {
            foreach (CardSO cardSO in tempPlayerDecklist)
            {
                CardContainer container = Instantiate(cardPrefab, cardCanvas.transform);
                Card card = new(cardSO);

                container.SetCard(card);
                container.gameObject.SetActive(true);
                programs.Add(card);
            }
        }

        public void DrawCard()
        {
            if (repository.Cards.Count <= 0) return;

            repository.RemoveCard(repository.Cards[0]);
            hand.AddCard(repository.Cards[0]);
            handView.UpdateVisuals();
        }

        public void AddCardToRig(Card card)
        {
            card.Zone.RemoveCard(card);
            rig.AddCard(card);
        }
    }
}