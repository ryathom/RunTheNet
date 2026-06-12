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
        public Trash Trash {get; private set;}

        public int Clicks {get; private set;}
        public int Energy {get; private set;}

        public void SetupRunner(List<Card> programs)
        {
            Repository = new(programs);
            Rig = new();
            Hand = new();
            Trash = new();

            Clicks = 0;
            Energy = 0;

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

        public void GainEnergy(int energy)
        {
            Energy += energy;
        }

        public void SpendEnergy(int energy)
        {
            if (energy > Energy)
            {
                Debug.Log("Tried to spend more energy than available");
            }

            Energy -= energy;
        }

        public void SetEnergy(int energy)
        {
            Energy = energy;
        }
    }
}