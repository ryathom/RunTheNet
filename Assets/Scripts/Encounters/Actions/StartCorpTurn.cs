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

    public class EndCorpTurn : IAction
    {
        public IEnumerator Execute()
        {
            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            if (info.Trace >= info.MaxTrace)
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter());
            }

            EncounterManager.Instance.ServerView.HideStackPointer();
            EncounterManager.Instance.Actions.AddAction(new NextPhase());
        }
    }
}