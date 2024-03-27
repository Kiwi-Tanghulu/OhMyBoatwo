using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : Feedback
{
    [SerializeField] private PoolableMono particleObj;

    public override void Play(Transform playTrm)
    {
        PoolableMono particle = PoolManager.Instance.Pop(particleObj.name, playTrm.position);
        particle.transform.rotation = playTrm.rotation;
    }
}
