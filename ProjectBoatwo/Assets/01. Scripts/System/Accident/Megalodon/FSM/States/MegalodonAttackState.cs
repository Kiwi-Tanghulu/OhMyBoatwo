using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAttackState : FSMState
{
    private float attackDistance;
    private bool attacked;

    public override void EnterState()
    {
        base.EnterState();

        attacked = false;
    }
}
