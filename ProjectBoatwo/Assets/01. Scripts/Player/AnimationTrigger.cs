using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public event Action AnimationEnd;
    private void AnimationEndTrigger()
    {
        AnimationEnd?.Invoke();
    }
}
