using System.Collections;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class CorpTurn : IAction
    {
        private float pointerDelay = 1f;

        public IEnumerator Execute()
        {
            Server server = EncounterManager.Instance.Server;
            ServerView serverView = EncounterManager.Instance.ServerView;

            for (int i = server.Slots.Count - 1; i >= 0; i--)
            {
                serverView.ShowStackPointer(i);

                if (server.Slots[i].Card != null)
                {
                    Debug.Log("here");
                    yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ExecuteSubroutines(server.Slots[i].Card));
                }

                yield return new WaitForSeconds(pointerDelay);
            }

            serverView.HideStackPointer();
            EncounterManager.Instance.Actions.AddAction(new NextPhase());
        }
    }
}