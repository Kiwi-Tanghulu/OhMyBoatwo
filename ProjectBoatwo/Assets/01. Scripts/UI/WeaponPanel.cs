using System.Collections.Generic;
using UnityEngine;

public class WeaponPanel : MonoBehaviour
{
    private List<WeaponSlot> weaponSlots = null;

    private void Awake()
    {
        transform.Find("WeaponSlots").GetComponentsInChildren<WeaponSlot>(weaponSlots);

    }

    public void FocusWeapon(int index)
    {
        if(index < -1 || index >= weaponSlots.Count)
            return;

        for(int i = 0; i < weaponSlots.Count; ++i)
            weaponSlots[i].Focus(false);
        weaponSlots[index].Focus(true);
    }
}
