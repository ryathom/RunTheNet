using UnityEngine;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class Repository : Zone
    {
        public Repository(List<Card> programs)
        {
            InstantiateRepo(programs);
            Shuffle();
        }

        public void InstantiateRepo(List<Card> programs)
        {
            foreach (Card card in programs)
            {
                Cards.Add(card);
                card.SetZone(this);
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < Cards.Count; i++) 
            {
                Card temp = Cards[i];
                int randomIndex = Random.Range(i, Cards.Count);
                Cards[i] = Cards[randomIndex];
                Cards[randomIndex] = temp;
            }
        }
    }
}