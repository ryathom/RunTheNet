using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;

namespace ryathom.RunTheNet.Encounters.Player
{
    public class Runner
    {
        private RunnerPlayArea playArea;

        public Repository Repository {get; private set;}
        public Hand Hand {get; private set;}
        public Rig Rig {get; private set;}

        public void SetupRunner(RunnerPlayArea playArea, List<Card> programs)
        {
            this.playArea = playArea;

            Repository = new(programs);
            Hand = new();
            Rig = new();

            playArea.SetupPlayArea(this);

            playArea.HandView.OnClickCardInHand += AddCardToRig;
        }

        public void AddCardToRig(Card card)
        {
            card.Zone.RemoveCard(card);
            Rig.AddCard(card);
        }

        public void DrawCard()
        {
            if (Repository.Cards.Count <= 0) return;

            Repository.RemoveCard(Repository.Cards[0]);
            Hand.AddCard(Repository.Cards[0]);
            playArea.HandView.UpdateVisuals();
        }
    }
}