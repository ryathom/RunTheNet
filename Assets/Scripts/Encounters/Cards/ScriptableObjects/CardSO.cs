using System.Collections.Generic;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Cards
{
    public class CardSO : ScriptableObject
    {   
        [SerializeReference, SubclassSelector]
        public List<IAbility> Abilities;

        public string cardText;
    }
}