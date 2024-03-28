using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MusketPistol : Equipment, IAimable, IAttackable
{
    [SerializeField] private CinemachineVirtualCamera cam;

    [SerializeField] Rig aimRig;
    public Rig AimRig => aimRig;

    private bool isAim;
    public bool IsAim => isAim;

    [SerializeField] float aimDuration;
    public float AimDuration => aimDuration;

    public void Aim(bool value)
    {
        StopAllCoroutines();
        StartCoroutine(Aiming(value));
    }

    public void Attack()
    {
        if (!isAim) return;
    }

    public override void EnterItem()
    {
        input.OnAimEvent += Aim;
        input.OnFireEvent += Attack;
        isAim = false;
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
        else isAim = false;
    }

}
