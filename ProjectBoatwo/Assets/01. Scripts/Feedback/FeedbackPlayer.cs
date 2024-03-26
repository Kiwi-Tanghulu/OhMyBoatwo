using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    private List<Feedback> feedbacks;

    private void Start()
    {
        feedbacks = new List<Feedback>();

        foreach (Transform feedback in transform)
        {
            feedbacks.Add(feedback.GetComponent<Feedback>());
        }
    }

    public void Play(Transform playTrm)
    {
        for (int i = 0; i < feedbacks.Count; i++)
            feedbacks[i].Play(playTrm);
    }
}