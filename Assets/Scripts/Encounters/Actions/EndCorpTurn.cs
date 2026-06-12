using System.Collections;

namespace ryathom.RunTheNet.Encounters.Actions
{
    public class EndCorpTurn : IAction
    {
        public IEnumerator Execute()
        {
            EncounterInfo info = EncounterManager.Instance.EncounterInfo;

            if (info.Trace >= info.MaxTrace)
            {
                yield return EncounterManager.Instance.Actions.ExecuteImmediate(new EndEncounter(success: false));
            }

            EncounterManager.Instance.ServerView.HideStackPointer();
            EncounterManager.Instance.Runner.SetEnergy(0);
            EncounterManager.Instance.Actions.AddAction(new NextPhase());
        }
    }
}