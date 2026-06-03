using System;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones {
    public class ServerView : ZoneView
    {
        private float cardSpacing = 344;

        private float xOffset = 0;
        private float yOffset = 0;
        private float offsetStep = 150;

        public Action<Card> OnClickCardInServer;

        public ServerGraph serverGraph;

        public override void UpdateVisuals()
        {
            Vector2 targetPosition = new (xOffset, yOffset);
                
            serverGraph.SetTargetPosition(this.transform.position + (Vector3)targetPosition);
        }

        public void ScrollUp()
        {
            yOffset += offsetStep;
            UpdateVisuals();
        }

        public void ScrollDown()
        {
            yOffset -= offsetStep;
            UpdateVisuals();
        }

        public void ScrollLeft()
        {
            xOffset -= offsetStep;
            UpdateVisuals();
        }

        public void ScrollRight()
        {
            xOffset += offsetStep;
            UpdateVisuals();
        }

        // Event responses
        //---------------------------------------------------------------------------------------------------------
        protected override void ClickCard(Card card)
        {
            OnClickCardInServer?.Invoke(card);
        }
    }
}