using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUnderZeroDecision : FSMDecision
{
    private Health brainHealth;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        brainHealth = brain.GetComponent<Health>();
    }

    public override bool MakeDecision()
    {
        if(!brainHealth)
        {
            Debug.Log("no exist health component");
            return false;
        }

        return brainHealth.CurrentHealth <= 0f;
    }
}
