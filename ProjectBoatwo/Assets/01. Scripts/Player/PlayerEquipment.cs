using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private PlayInputSO input;

    [SerializeField] private Equipment mainEquipment;
    [SerializeField] private Equipment subEquimpent;

    private Equipment currentEquipment;
    private Equipment nextEquipment;

    [SerializeField] private Rig mainEquipmentRig;
    [SerializeField] private Rig subEquipmentRig;

    private Rig currentEquipmentRig;
    private Rig nextEquipmentRig;

    [SerializeField] private float weaponChangeDuration;

    private bool isChange;

    private void Start()
    {
        input.OnChangeEvent += ChangeWeapon;
        currentEquipment = mainEquipment;
        nextEquipment = subEquimpent;
        currentEquipmentRig = mainEquipmentRig;
        nextEquipmentRig = subEquipmentRig;
        isChange = false;

        currentEquipmentRig.weight = 1f;
        nextEquipmentRig.weight = 0f;
    }

    private void OnDestroy()
    {
        input.OnChangeEvent -= ChangeWeapon;
    }
    private void ChangeWeapon()
    {
        if(!isChange)
            StartCoroutine(SwitchEquipment());
    }

    private IEnumerator SwitchEquipment()
    {
        isChange = true;
        while (true)
        {
            currentEquipmentRig.weight -= Time.deltaTime / weaponChangeDuration;
            if(currentEquipmentRig.weight <= 0.02f)
            {
                currentEquipmentRig.weight = 0f;
                break;
            }
            yield return null;
        }

        while (true)
        {
            nextEquipmentRig.weight += Time.deltaTime / weaponChangeDuration;
            if(nextEquipmentRig.weight >= 0.98f)
            {
                nextEquipmentRig.weight = 1f;
                break;
            }
            yield return null;
        }

        SwapEquipment();

        isChange = false;
    }

    private void SwapEquipment()
    {
        Equipment equipTemp = currentEquipment;
        Rig rigTemp = currentEquipmentRig;

        currentEquipment = nextEquipment;
        currentEquipmentRig = nextEquipmentRig;

        nextEquipment = equipTemp;
        nextEquipmentRig = rigTemp;
    }
}
