using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class StartCorpTurn : IAction
    {
        public IEnumerator Execute()
        {
            Server server = EncounterManager.Instance.Server;

            EncounterManager.Instance.Actions.SetProgramCounter(server.Slots.Count - 1);

            EncounterManager.Instance.Actions.AddAction(new ExecuteSubroutines(server.Slots.Count - 1));

            return null;
        }
    }
}