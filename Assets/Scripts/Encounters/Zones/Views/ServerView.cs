using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        private float cardSpacing = 344;

        private float offset = 0;
        private float offsetStep = 150;

        public override void UpdateVisuals()
        {
            for (int i = 0; i < containers.Count; i++)
            {
                float y = i * cardSpacing;
                Vector2 targetPosition = new (0, y + offset);

                containers[i].SetTargetPosition(this.transform.position + (Vector3)targetPosition);
                containers[i].ShowVisual(true);
            }
        }

        public void ScrollUp()
        {
            offset += offsetStep;
            UpdateVisuals();
        }

        public void ScrollDown()
        {
            offset -= offsetStep;
            UpdateVisuals();
        }
    }
}