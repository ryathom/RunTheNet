using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class Trash : Zone
    {
        public Trash() : base()
        {
        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);

            card.Activate();
            
            if (card is Program program)
            {
                program.ResetStrength();
            }
        }
    }
}