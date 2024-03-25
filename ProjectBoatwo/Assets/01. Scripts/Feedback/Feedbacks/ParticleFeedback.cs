using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : Feedback
{
    [SerializeField] private ParticleSystem particlePrefab;
    private ParticleSystem particle;

    private void Awake()
    {
        particle = Instantiate(particlePrefab, transform);
    }

    public override void Play(Transform playTrm)
    {
        particle.transform.position = playTrm.position;

        particle.Play();
    }
}
