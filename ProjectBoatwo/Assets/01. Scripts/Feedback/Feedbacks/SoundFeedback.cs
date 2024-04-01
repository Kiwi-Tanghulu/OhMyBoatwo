using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFeedback : Feedback
{
    [SerializeField] private AudioLibrarySO audioLib;
    [SerializeField] private string clipName;
    
    public override void Play(Transform playTrm)
    {
        DEFINE.GlobalAudioPlayer.PlayOneShot(audioLib[clipName]);
    }
}
