using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Accident : MonoBehaviour
{
    [SerializeField] private AccidentType accidentType;
    public AccidentType AccidentType => accidentType;

    public bool isActive { get; private set; }

    public abstract void InitAccident();
    public virtual void StartAccident()
    {
        isActive = true;
    }
    public abstract void UpdateAccident();
    public virtual void EndAccident()
    {
        AccidentManager.Instance.EndAccident(this);
        isActive = false;
    }
}
