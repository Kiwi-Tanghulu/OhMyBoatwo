using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutlass : Equipment
{
    [SerializeField] private Equipment nextEquipment;

    private void Start()
    {
        visual.gameObject.SetActive(false);
    }
    public override void EnterItem()
    {
        base.EnterItem();
        input.OnChangeEvent += StartOffAnimation;
        trigger.AnimationEnd += ChangeNextEquipment;
        animator.Play("OnCutlass");
        isActive = true;
    }

    public override void ExitItem()
    {
        base.ExitItem();
        input.OnChangeEvent -= StartOffAnimation;
        trigger.AnimationEnd -= ChangeNextEquipment;
        nextEquipment.EnterItem();
    }

    public void StartOffAnimation()
    {
        animator.enabled = true;
        animator.Play("Off" + equipmentName);
    }

    public void ChangeNextEquipment()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            ExitItem();
        }
    }
}
