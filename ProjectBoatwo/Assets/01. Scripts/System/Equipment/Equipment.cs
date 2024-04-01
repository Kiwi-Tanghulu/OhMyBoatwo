using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Equipment : MonoBehaviour
{
    [SerializeField] protected string equipmentName;
    [SerializeField] protected Animator animator;
    [SerializeField] protected AnimationTrigger trigger;
    [SerializeField] protected Transform visual;
    [SerializeField] protected PlayInputSO input;
    protected bool isActive;
    public virtual void EnterItem()
    {
        visual.gameObject.SetActive(true);
    }
    public virtual void ExitItem()
    {
        visual.gameObject.SetActive(false);
    }

}
