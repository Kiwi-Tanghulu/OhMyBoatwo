using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : Feedback
{
    [SerializeField] private PoolableMono particleObj;

    public override void Play(Transform playTrm)
    {
        PoolManager.Instance.Pop(particleObj.name, playTrm.position);
    }
}
