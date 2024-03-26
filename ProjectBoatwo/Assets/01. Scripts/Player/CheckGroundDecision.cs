using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGroundDecision : FSMDecision
{
    [SerializeField] private BoxCollider groundCheckCol;
    [SerializeField] private LayerMask groundLayer;
    public override bool MakeDecision()
    {
        return Physics.OverlapBox(groundCheckCol.transform.position + groundCheckCol.center,
            groundCheckCol.size / 2, Quaternion.identity, groundLayer).Length > 0; ;
    }
}
