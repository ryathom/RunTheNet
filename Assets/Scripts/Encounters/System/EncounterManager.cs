using UnityEngine;
using System;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using ryathom.RunTheNet.Encounters.Player;
using ryathom.RunTheNet.Encounters.Actions;
using ryathom.RunTheNet.Run;

namespace ryathom.RunTheNet.Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager Instance {get; private set;}

        [SerializeField] private List<CardSO> tempServerDecklist;
        [SerializeField] private CardContainer cardPrefab;
        [SerializeField] private CardContainer corpCardPrefab;
        [SerializeField] private Canvas cardCanvas;

        private List<Card> programs;
        private List<Card> hardware;

        public ActionSystem Actions {get; private set;}
        public Runner Runner {get; private set;}
        public Server Server {get; private set;}

        public EncounterInfo EncounterInfo {get; private set;}
        
        [SerializeField] private ServerView serverView;
        public ServerView ServerView {get => serverView;}
        [SerializeField] private PlayerController playerController;

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

            EncounterInfo = new();
            EncounterInfo.CurrentPhase.Enter();
        }

        public void Update()
        {
            if (Actions == null) return;

            if (Actions.Busy == false)
            {
                StartCoroutine(Actions.ExecuteNextAction());
            }
        }

        public void OnDestroy()
        {
            Server.OnDestroy();
        }

        // Game flow
        //---------------------------------------------------------------------------------------------------------
        private void SetupRunner()
        {
            SetupPrograms();
            SetupHardware();

            Runner = new();
            Runner.SetupRunner(programs);
            playerController.Setup(Actions, Runner);

            foreach(Card card in hardware)
            {
                Runner.Rig.AddCard(card);
            }
        }

        private void SetupPrograms()
        {
            programs = RunManager.Instance.Programs;

            foreach (Card card in programs)
            {
                CardContainer container = Instantiate(cardPrefab, cardCanvas.transform);

                container.SetCard(card);
                container.gameObject.SetActive(true);
            }
        }

        private void SetupHardware()
        {
            hardware = RunManager.Instance.Hardware;

            foreach (Card card in hardware)
            {
                CardContainer container = Instantiate(cardPrefab, cardCanvas.transform);

                container.SetCard(card);
                container.gameObject.SetActive(true);
            }
        }

        private void SetupServer()
        {
            Server = new();
            serverView.SetZone(Server);
            // serverView.HideStackPointer();

            for (int i = 0; i < tempServerDecklist.Count; i++)
            {
                CardContainer container = Instantiate(cardPrefab, serverView.transform);
                CardSO cardSO = tempServerDecklist[i];
                
                Card card = null;

                if (cardSO == null)
                {
                    continue;
                } else if (cardSO is IceSO iceSO)
                {
                    card = new Ice(iceSO);
                } else if (cardSO is ServerAssetSO assetSO)
                {
                    card = new ServerAsset(assetSO);
                } else
                {
                    Debug.LogError("Unrecognised card type " + cardSO);
                }

                container.SetCard(card);
                container.gameObject.SetActive(true);
                Server.AddCard(card, i);
            }
        }

        public void RunnerDrawCard()
        {
            Actions.AddAction(new ClickToDrawCard());
        }

        public void EndTurn()
        {
            Actions.AddAction(new NextPhase());
        }

        public void EndEncounter()
        {
            GameManager.Instance.LoadScene("RunScene");
        }
    }
}