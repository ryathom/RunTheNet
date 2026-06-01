using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using ryathom.RunTheNet.Encounters.Player;
using UnityEngine;
using System;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.System
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance {get; private set;}

        [SerializeField] private List<CardSO> tempPlayerDecklist;
        [SerializeField] private List<CardSO> tempServerDecklist;
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private CardContainer corpCardPrefab;
        [SerializeField] private Canvas cardCanvas;

        private List<Card> programs;

        public ActionSystem Actions {get; private set;}
        public Runner Runner {get; private set;}
        public Server Server {get; private set;}
        
        [SerializeField] private RunnerPlayArea playArea;
        [SerializeField] private ServerView serverView;

        // Unity Messages
        //---------------------------------------------------------------------------------------------------------
        private void Awake() 
        {
            if (Instance == null) {
                Instance = this;
            } else
            {
                Destroy(gameObject);
            }
        }

        public void Start()
        {
            Actions = new();
            SetupRunner();
            SetupServer();
        }

        public void Update()
        {
            if (Actions == null) return;

            if (Actions.Busy == false)
            {
                StartCoroutine(Actions.ExecuteNextAction());
            }
        }

        // Game flow
        //---------------------------------------------------------------------------------------------------------
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

        public void RunnerDrawCard()
        {
            Actions.AddAction(new ClickToDrawCard());
        }

        public void EndTurn()
        {
            Debug.Log("End turn");
        }
    }
}