using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class FootStepAudioPlayer : AudioPlayer
{
    [SerializeField] private string clipName;
    [SerializeField] private int clipCount;

    public void PlayFootStepSound()
    {
        string clipName = $"{this.clipName}{UnityEngine.Random.Range(1, clipCount + 1)}";
        player?.PlayOneShot(audioLibrary[clipName]);
    }
}
