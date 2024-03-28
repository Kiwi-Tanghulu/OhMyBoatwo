using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairGauge : MonoBehaviour
{
    private Image gaugeImage;

    private void Awake()
    {
        gaugeImage = GetComponent<Image>();

        WaterLeak[] leaks = GameObject.FindObjectsByType<WaterLeak>(FindObjectsSortMode.None);
        for (int i = 0; i < leaks.Length; i++)
        {
            leaks[i].OnStartRepairing += WaterLeak_OnStartRepairing;
            leaks[i].OnRepairing += SetGaugeVlaue;
            leaks[i].OnEndRepairing += WaterLeak_OnEndRepairing;
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void SetGaugeVlaue(float value)
    {
        gaugeImage.fillAmount = value;
    }

    private void WaterLeak_OnStartRepairing()
    {
        gameObject.SetActive(true);
    }

    private void WaterLeak_OnEndRepairing(bool value)
    {
        gameObject.SetActive(false);
    }
}
