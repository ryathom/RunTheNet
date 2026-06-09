using System.Collections;
using ryathom.RunTheNet.Encounters.Cards;
using ryathom.RunTheNet.Encounters.Player;
using ryathom.RunTheNet.Encounters.Zones;
using UnityEngine;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class InstallProgram : IAction
    {
        public Program Program {get; private set;}
        public ServerSlot Slot {get; private set;}
        private Runner runner;

        public InstallProgram(Program program, ServerSlot slot)
        {
            Program = program;
            Slot = slot;
        }


        public IEnumerator Execute()
        {
            runner = EncounterManager.Instance.Runner;

            if (Program.Cost.CanPay())
            {
                yield return Program.Cost.Pay();
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new ChangeZone(Program, EncounterManager.Instance.Server, Slot));
            } else
            {
                Debug.Log("Program installation failed");
            }

        }
    }
}