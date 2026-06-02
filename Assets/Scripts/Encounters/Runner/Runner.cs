using UnityEngine;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Player
{
    public class Runner
    {
        private RunnerPlayArea playArea;

        public Repository Repository {get; private set;}
        public Hand Hand {get; private set;}
        public Rig Rig {get; private set;}

        public int Clicks {get; private set;}

        public void SetupRunner(RunnerPlayArea playArea, List<Card> programs)
        {
            this.playArea = playArea;

            Repository = new(programs);
            Hand = new();
            Rig = new();

            Clicks = 3;

            playArea.SetupPlayArea(this);

            playArea.HandView.OnClickCardInHand += AddCardToRig;

            for (int i = 0; i < 5; i++)
            {
                EncounterManager.Instance.Actions.AddAction(new DrawCard());
            }
        }

        public void AddCardToRig(Card card)
        {
            EncounterManager.Instance.Actions.AddAction(new InstallProgram(card));
        }

        public void SpendClicks(int clicks)
        {
            if (clicks > Clicks)
            {
                Debug.Log("Tried to spend more clicks than available");
            }

            Clicks -= clicks;
        }
    }
}