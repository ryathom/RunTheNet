using System.Collections.Generic;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardSO : ScriptableObject
    {
        public Sprite BackgroundImage;
        
        [SerializeReference, SubclassSelector]
        public List<IAbility> Abilities;

        public string cardText;
    }
}