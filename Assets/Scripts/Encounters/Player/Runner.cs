using UnityEngine;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.Player
{
    public class Runner
    {

        public Repository Repository {get; private set;}
        public Hand Hand {get; private set;}
        public Rig Rig {get; private set;}

        public int Clicks {get; private set;}

        public void SetupRunner(List<Card> programs)
        {
            Repository = new(programs);
            Hand = new();
            Rig = new();

            Clicks = 3;

            for (int i = 0; i < 5; i++)
            {
                EncounterManager.Instance.Actions.AddAction(new DrawCard());
            }
        }

        public void SpendClicks(int clicks)
        {
            if (clicks > Clicks)
            {
                Debug.Log("Tried to spend more clicks than available");
            }

            Clicks -= clicks;
        }

        public void SetClicks(int clicks)
        {
            Clicks = clicks;
        }
    }
}