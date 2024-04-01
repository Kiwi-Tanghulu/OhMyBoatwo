using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Accident : MonoBehaviour
{
    [Space] 
    [SerializeField] private AccidentType accidentType;
    public AccidentType AccidentType => accidentType;

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
