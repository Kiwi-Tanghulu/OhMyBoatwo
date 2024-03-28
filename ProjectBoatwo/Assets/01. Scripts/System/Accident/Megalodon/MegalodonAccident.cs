using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAccident : Accident
{
    [SerializeField] private float startDistance;

    public override void InitAccident()
    {
        
    }

    public override void StartAccident()
    {
        base.StartAccident();

        Vector3 dir = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0f, UnityEngine.Random.Range(-1f, 1f));
        transform.position = Ship.Instance.transform.position + dir * startDistance;
    }

    public override void UpdateAccident()
    {
        
    }
}
