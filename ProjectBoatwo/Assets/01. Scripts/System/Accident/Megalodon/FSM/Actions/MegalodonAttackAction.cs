using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAttackAction : MegalodonFSMAction
{
    [SerializeField] DetectTargetParams targetParam = null;
    [SerializeField] AttackTargetParams attackParam = null;

    public override void EnterState()
    {
        //play attack animation
        Debug.Log("megalodon attack");
        base.EnterState();
    }
}
