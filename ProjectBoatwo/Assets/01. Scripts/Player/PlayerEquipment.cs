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

    [SerializeField] private float weaponChangeDuration;

    private bool isChange;

    private void Start()
    {
        input.OnChangeEvent += ChangeWeapon;
        currentEquipment = mainEquipment;
        isChange = false;

        mainEquipment.EnterItem();
    }

    private void OnDestroy()
    {
        input.OnChangeEvent -= ChangeWeapon;
    }
    private void ChangeWeapon()
    {
        if (!isChange)
        {

        }
    }
}
