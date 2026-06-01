using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        private float cardSpacing = 344;

        public override void UpdateVisuals()
        {
            for (int i = 0; i < containers.Count; i++)
            {
                float y = i * cardSpacing;
                Vector2 targetPosition = new (0, y);

                containers[i].SetTargetPosition(this.transform.position + (Vector3)targetPosition);
                containers[i].ShowVisual(true);
            }
        }
    }
}