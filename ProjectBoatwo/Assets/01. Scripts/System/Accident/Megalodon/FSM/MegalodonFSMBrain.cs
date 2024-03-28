using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSMBrain : FSMBrain
{
    [SerializeField] private MegalodonInfoSO info;
    public MegalodonInfoSO Info => info;

    public MegalodonMovement Movement { get; private set; }

    public Ship targetShip { get; private set; }

    protected override void Awake()
    {
        targetShip = Ship.Instance;
        Movement = GetComponent<MegalodonMovement>();
        
        base.Awake();
    }
}
