using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class TrashView : ZoneView
    {
        private Trash trash;

        public override void UpdateVisuals()
        {
            foreach(Card card in trash.Cards)
            {
                card.Container.SetTargetPosition(this.transform.position);
            }
        }

        public override void SetZone(Zone zone)
        {
            base.SetZone(zone);
            this.trash = (Trash)zone;
        }
    }
}