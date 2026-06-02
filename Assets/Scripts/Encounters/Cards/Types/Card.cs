using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public abstract class Card
    {
        public CardSO CardSO {get; protected set;}

        public List<IAbility> Abilities {get; private set;}

        public CardContainer Container {get; private set;}
        public Zone Zone {get; private set;}

        public Card(CardSO cardSO)
        {
            this.CardSO = cardSO;

            Abilities = new();
            foreach(IAbility ability in CardSO.Abilities)
            {
                IAbility copy = ability.Copy();
                Abilities.Add(copy);
            }
        }

        public void SetContainer(CardContainer container)
        {
            Container = container;
        }

        public void SetZone(Zone zone)
        {
            Zone = zone;
        }
    }
}