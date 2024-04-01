using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Accident : MonoBehaviour
{
    [SerializeField] protected AudioLibrarySO audioLib;

    [Space] 
    [SerializeField] private AccidentType accidentType;
    public AccidentType AccidentType => accidentType;

    public bool isActive { get; protected set; }

    public abstract void InitAccident();
    public virtual void StartAccident()
    {
        gameObject.SetActive(true);
        isActive = true;
    }
    public abstract void UpdateAccident();
    public virtual void EndAccident()
    {
        AccidentManager.Instance.EndAccident(this);
        isActive = false;
        gameObject.SetActive(false);
    }
}
