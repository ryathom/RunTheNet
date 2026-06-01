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
        [SerializeField] private List<CardSO> tempServerDecklist;
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private CardContainer corpCardPrefab;
        [SerializeField] private Canvas cardCanvas;

        private List<Card> programs;

        public Runner Runner {get; private set;}
        public Server Server {get; private set;}
        
        [SerializeField] private RunnerPlayArea playArea;
        [SerializeField] private ServerView serverView;

        public void Start()
        {
            SetupRunner();
            SetupServer();
        }

        private void SetupRunner()
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

        private void SetupServer()
        {
            Server = new();
            serverView.SetZone(Server);

            foreach (CardSO cardSO in tempServerDecklist)
            {
                CardContainer container = Instantiate(cardPrefab, serverView.transform);
                Card card = new(cardSO);

                container.SetCard(card);
                container.gameObject.SetActive(true);
                Server.AddCard(card);
            }
        }

        public void DrawCard()
        {
            Runner.DrawCard();
        }

        public void EndTurn()
        {
            Debug.Log("End turn");
        }
    }
}