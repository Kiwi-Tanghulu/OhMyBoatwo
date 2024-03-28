using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipHealth : Health
{
    [SerializeField] private float repairHealAmount;

    protected override void Start()
    {
        base.Start();

        foreach (WaterLeak leak in Ship.Instance.Leaks)
        {
            leak.OnEndRepairing += Leak_OnEndRepairing;
        }
    }

    private void Leak_OnEndRepairing(bool isSuccessRepair)
    {
        if (!isSuccessRepair)
            return;

        Heal(repairHealAmount);
    }
}
