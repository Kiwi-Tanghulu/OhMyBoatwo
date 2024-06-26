using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMBrain : FSMBrain
{
    [SerializeField] private MegalodonStateInfoListSO info;
    public MegalodonStateInfoListSO Info => info;

    public MegalodonMovement Movement { get; private set; }

    protected override void Awake()
    {
        Movement = GetComponent<MegalodonMovement>();

        base.Awake();
    }
}
