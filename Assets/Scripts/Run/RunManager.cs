using System.Collections.Generic;
using ryathom.RunTheNet.Encounters;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    public class RunManager : MonoBehaviour
    {
        public static RunManager Instance {get; private set;}

        [SerializeField] private List<ProgramSO> startingPrograms;
        [SerializeField] private List<HardwareSO> startingHardware;

        public List<Card> Programs {get; private set;}
        public List<Card> Hardware {get; private set;}

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

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SetupCards();
        }

        // Game flow
        //---------------------------------------------------------------------------------------------------------
        public void SetupCards()
        {
            Programs = new();
            Hardware = new();

            foreach (ProgramSO programSO in startingPrograms)
            {
                Program card = new(programSO);
                Programs.Add(card);
            }

            foreach (HardwareSO hardwareSO in startingHardware)
            {
                Hardware card = new(hardwareSO);
                Hardware.Add(card);
            }
        }

        public void StartEncounter()
        {
            GameManager.Instance.LoadScene("EncounterScene");
        }
    }
}