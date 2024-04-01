using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Accident : MonoBehaviour
{
    [SerializeField] private AccidentInfoSO info;
    public AccidentInfoSO Info => info;

    public bool isActive { get; protected set; }

    public UnityEvent OnStartAccident;
    public UnityEvent OnEndAccident;

    public abstract void InitAccident();
    public virtual void StartAccident()
    {
        gameObject.SetActive(true);
        isActive = true;
        OnStartAccident?.Invoke();
    }
    public abstract void UpdateAccident();
    public virtual void EndAccident()
    {
        AccidentManager.Instance.EndAccident(this);
        isActive = false;
        gameObject.SetActive(false);
        OnEndAccident?.Invoke();
    }
}
