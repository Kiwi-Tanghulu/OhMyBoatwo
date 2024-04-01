using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXFeedback : Feedback
{
    [SerializeField] private VisualEffect visualEffect;

    public override void Play(Transform playTrm)
    {
        VisualEffect effect = Instantiate(visualEffect, playTrm.position, playTrm.rotation);
        effect.Play();
    }
}
