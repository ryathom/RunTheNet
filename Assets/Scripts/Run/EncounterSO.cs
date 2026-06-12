using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Cards;
using UnityEngine;

namespace ryathom.RunTheNet.Run
{
    [CreateAssetMenu(fileName = "EncounterSO", menuName = "Scriptable Objects/EncounterSO")]
    public class EncounterSO : ScriptableObject
    {
        public int CreditsReward;
        public List<ProgramSO> ProgramRewards;

        public List<CardSO> ServerList;
    }
}