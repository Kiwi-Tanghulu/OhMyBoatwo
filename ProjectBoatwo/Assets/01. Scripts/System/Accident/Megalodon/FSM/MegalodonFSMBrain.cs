using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMBrain : FSMBrain
{
    [SerializeField] private MegalodonInfoSO info;
    public MegalodonInfoSO Info => info;

    public MegalodonMovement Movement { get; private set; }

    [SerializeField] private Ship targetShip;
    public Ship TargetShip => targetShip;

    protected override void Awake()
    {
        Movement = GetComponent<MegalodonMovement>();

        base.Awake();
    }
}
