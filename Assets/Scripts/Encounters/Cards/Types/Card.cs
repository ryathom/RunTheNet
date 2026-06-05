using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public abstract class Card
    {
        public CardSO CardSO {get; protected set;}
        public string Name {get => CardSO.name;}

        public List<IAbility> Abilities {get; private set;}

        public CardContainer Container {get; private set;}
        public Zone Zone {get; private set;}

        public bool Active {get; private set;}

        public Card(CardSO cardSO)
        {
            this.CardSO = cardSO;

            Abilities = new();
            foreach(IAbility ability in CardSO.Abilities)
            {
                IAbility copy = ability.Copy();
                Abilities.Add(copy);
            }

            Active = true;
        }

        public void SetContainer(CardContainer container)
        {
            Container = container;
        }

        public void SetZone(Zone zone)
        {
            Zone = zone;
        }

        public void Activate()
        {
            Active = true;
            Container.ShowVisual(true);
        }

        public void Deactivate()
        {
            Active = false;
            Container.ShowVisual(true);
        }
    }
}