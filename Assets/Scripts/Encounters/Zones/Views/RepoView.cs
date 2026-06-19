using ryathom.RunTheNet.Encounters.Cards;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class RepoView : ZoneView
    {
        private Repository repo;

        public override void UpdateVisuals()
        {
            foreach(Card card in repo.Cards)
            {
                card.Container.SetTargetPosition(this.transform.position);
            }
        }

        public override void SetZone(Zone zone)
        {
            base.SetZone(zone);
            this.repo = (Repository)zone;
        }
    }
}