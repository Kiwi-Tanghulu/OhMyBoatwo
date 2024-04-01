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
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void RegistLeak(WaterLeak leak)
    {
        leak.OnStartRepairing += WaterLeak_OnStartRepairing;
        leak.OnRepairing += SetGaugeVlaue;
        leak.OnEndRepairing += WaterLeak_OnEndRepairing;
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
