using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLayerFSMDecision : FSMDecision 
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;

    public override bool MakeDecision()
    {
        return 0 < Physics.OverlapSphere(brain.transform.position, distance, layer).Length;
    }
}
