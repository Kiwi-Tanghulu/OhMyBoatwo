using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Content;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class MusketPistol : Equipment, IAimable, IAttackable
{
    [SerializeField] private UnityEvent fireEvent;
    [SerializeField] private CinemachineVirtualCamera cam;

    [SerializeField] Rig aimRig;
    public Rig AimRig => aimRig;

    private bool isAim;
    public bool IsAim => isAim;

    [SerializeField] float aimDuration;
    public float AimDuration => aimDuration;

    private bool canAttack;
    public void Aim(bool value)
    {
        StopAllCoroutines();
        if (value == false) isAim = false;
        StartCoroutine(Aiming(value));
    }

    public void Attack()
    {
        if (!isAim || !canAttack) return;
        fireEvent?.Invoke();
    }

    public override void EnterItem()
    {
        input.OnAimEvent += Aim;
        input.OnFireEvent += Attack;
        isAim = false;
        canAttack = true;
    }
    public override void ExitItem()
    {
        input.OnAimEvent -= Aim;
        input.OnFireEvent -= Attack;
    }
    private IEnumerator Aiming(bool value)
    {
        while (true)
        {
            aimRig.weight += Time.deltaTime / (value ? aimDuration : -aimDuration);
            cam.m_Lens.FieldOfView = Mathf.Lerp(60f, 50f, aimRig.weight);
            if(1f - aimRig.weight < 0.02f)
            {
                aimRig.weight = value ? 1 : -1;
                break;
            }
            yield return null;
        }

        if (aimRig.weight > 0.98f) isAim = true;
    }

}
