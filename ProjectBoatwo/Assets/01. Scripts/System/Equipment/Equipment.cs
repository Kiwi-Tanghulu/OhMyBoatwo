using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Equipment : MonoBehaviour
{
    [SerializeField] protected Transform visual;
    [SerializeField] protected PlayInputSO input;
    public virtual void EnterItem()
    {
        visual.gameObject.SetActive(true);
    }
    public virtual void ExitItem()
    {
        visual.gameObject.SetActive(false);
    }

}
