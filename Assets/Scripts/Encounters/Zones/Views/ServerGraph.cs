using PrimeTween;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Zones
{
    public class ServerGraph : MonoBehaviour
    {
        public CardContainer RootNode;




        public void SetTargetPosition(Vector2 pos)
        {
            if ((Vector2)transform.position != pos)
            {
                Tween.Position(transform, pos, 0.25f);
            }
        }
    }
}