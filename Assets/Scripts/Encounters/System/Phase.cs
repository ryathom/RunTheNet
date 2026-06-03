using System;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters
{
    [Serializable]
    public abstract class Phase
    {
        public abstract Phase NextPhase();

        public virtual void Enter() {}
        public virtual void Exit() {}
    }

    [Serializable]
    public class RunnerStartPhase : Phase
    {
        public override void Enter()
        {
            base.Enter();

            EncounterManager.Instance.Actions.AddAction(new NextPhase());
        }

        public override Phase NextPhase()
        {
            return new RunnerMainPhase();
        }
    }

    [Serializable]
    public class RunnerMainPhase : Phase
    {
        public override Phase NextPhase()
        {
            return new RunnerEndPhase();
        }
    }

    [Serializable]
    public class RunnerEndPhase : Phase
    {
        public override void Enter()
        {
            base.Enter();

            EncounterManager.Instance.Actions.AddAction(new NextPhase());
        }

        public override Phase NextPhase()
        {
            return new CorpPhase();
        }
    }

    [Serializable]
    public class CorpPhase : Phase
    {
        public override Phase NextPhase()
        {
            return new RunnerStartPhase();
        }
    }
}