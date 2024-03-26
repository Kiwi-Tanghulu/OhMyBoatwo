using System.Collections.Generic;
using UnityEngine;

public class FSMState : MonoBehaviour
{
    [SerializeField] bool autoTransitioning = true;

    private FSMBrain brain;

    private List<FSMAction> actions;
    private List<FSMTransition> transitions;
    public virtual void Init(FSMBrain brain)
    {
        this.brain = brain;

        actions = new List<FSMAction>();
        GetComponents<FSMAction>(actions);
        actions.ForEach(i => i.Init(brain, this));

        transitions = new List<FSMTransition>();
        GetComponentsInChildren<FSMTransition>(transitions);
        transitions.ForEach(i => i.Init(brain, this));
    }

    public virtual void EnterState()
    {
        actions.ForEach(i => i.EnterState());

        if (autoTransitioning)
            transitions.ForEach(i => i.EnterState());
    }

    public void UpdateState()
    {

        if (autoTransitioning)
        {
            foreach (FSMTransition transition in transitions)
            {
                if (transition.CheckDecisions())
                {
                    brain.ChangeState(transition.TargetState);
                    return;
                }
            }
        }

        actions.ForEach(i => i.UpdateState());
    }

    public virtual void ExitState()
    {
        actions.ForEach(i => i.ExitState());

        if (autoTransitioning)
            transitions.ForEach(i => i.ExitState());
    }
}
