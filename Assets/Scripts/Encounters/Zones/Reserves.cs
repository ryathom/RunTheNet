using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class Reserves : Zone
    {
        public Reserves()
        {
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