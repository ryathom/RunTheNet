using System.Collections;
using System.Collections.Generic;
using ryathom.RunTheNet.Encounters.Actions;

namespace ryathom.RunTheNet.Encounters.System
{
    public class ActionSystem
    {
        public Queue<IAction> ActionQueue {get; private set;}
        public IAction CurrentAction {get; private set;}

        public bool Busy {get; private set;}

        public ActionSystem()
        {
            ActionQueue = new();
            Busy = false;
        }

        public void AddAction(IAction action)
        {
            ActionQueue.Enqueue(action);
        }

        public IEnumerator ExecuteNextAction()
        {
            if (ActionQueue.Count > 0)
            {
                Busy = true;
                CurrentAction = ActionQueue.Dequeue();
                yield return CurrentAction.Execute();

                Busy = false;
            }
        }

        public IEnumerator ExecuteImmediate(IAction action)
        {
            yield return action.Execute();
        }
    }
}