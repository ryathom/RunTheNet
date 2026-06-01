using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using ryathom.RunTheNet.Encounters.Player;
using UnityEngine;
using System;

namespace ryathom.RunTheNet.Encounters.System
{
    public class EncounterManager : MonoBehaviour
    {
        [SerializeField] private List<CardSO> tempPlayerDecklist;
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private Canvas cardCanvas;

        private List<Card> programs;

        public Runner Runner {get; private set;}
        
        [SerializeField] private RunnerPlayArea playArea;

        public void Start()
        {
            programs = new();
            SetupPrograms();

            Runner = new();
            Runner.SetupRunner(playArea, programs);
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
            Runner.DrawCard();
        }
    }
}