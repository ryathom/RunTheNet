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

            int pc = server.GetFirstOccupiedIndex();

            EncounterManager.Instance.Actions.SetProgramCounter(pc);

            EncounterManager.Instance.Actions.AddAction(new ExecuteSubroutines(pc));

            return null;
        }
    }
}