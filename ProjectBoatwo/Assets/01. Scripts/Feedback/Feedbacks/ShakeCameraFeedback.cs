using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraFeedback : Feedback
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float duration;
    [SerializeField] private float force;

    public override void Play(Transform playTrm)
    {
        CameraManager.Instance.ShakeCam(velocity, duration, force);
    }
}
