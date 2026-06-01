using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    [CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Objects/CardSO")]
    public class CardSO : ScriptableObject
    {
        public Sprite BackgroundImage;
        
        public CardType cardType;
        public string cardText;
    }

    public enum CardType
    {
        Program,
    }
}