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

    [SerializeField] private Rig playerHandRig;

    [SerializeField] private float weaponChangeDuration;

    private bool isChange;

    private void Start()
    {
        input.OnChangeEvent += ChangeWeapon;
        currentEquipment = mainEquipment;
        isChange = false;

        playerHandRig.weight = 1f;

        mainEquipment.EnterItem();
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
            playerHandRig.weight -= Time.deltaTime / weaponChangeDuration;
            if(playerHandRig.weight <= 0.02f)
            {
                playerHandRig.weight = 0f;
                break;
            }
            yield return null;
        }

        while (true)
        {
            playerHandRig.weight += Time.deltaTime / weaponChangeDuration;
            if(playerHandRig.weight >= 0.98f)
            {
                playerHandRig.weight = 1f;
                break;
            }
            yield return null;
        }

        //SwapEquipment();

        isChange = false;
    }
}
