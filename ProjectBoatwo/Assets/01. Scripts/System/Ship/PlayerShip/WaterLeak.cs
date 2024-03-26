using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLeak : MonoBehaviour
{
    public UnityEvent onProduced;
    public UnityEvent onRepaired;

    public bool isWorking { get; private set; }

    private void Start()
    {
        gameObject.SetActive(false);    
        isWorking = false;
    }

    public void Produce()
    {
        
        if (isWorking)
            return;
        
        isWorking = true;
        gameObject.SetActive(true);

        onProduced?.Invoke();
    }

    public void Repair()
    {
        Debug.Log("repair leak");
        onRepaired?.Invoke();

        gameObject.SetActive(false);
        isWorking = false;
    }
}
