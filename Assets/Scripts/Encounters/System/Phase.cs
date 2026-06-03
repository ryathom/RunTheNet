using System;

namespace ryathom.RunTheNet.Encounters
{
    [Serializable]
    public abstract class Phase
    {
        public abstract Phase NextPhase();

        public virtual void Enter() {}
        public virtual void Exit() {}

        public static Action<Phase> OnPhaseEnter;
    }

    [Serializable]
    public class RunnerStartPhase : Phase
    {
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