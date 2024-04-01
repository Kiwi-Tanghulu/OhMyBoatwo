using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Content;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class MusketPistol : Equipment, IAimable, IAttackable
{
    [SerializeField] private Equipment nextEquipment;
    [SerializeField] private UnityEvent fireEvent;
    [SerializeField] private CinemachineVirtualCamera cam;

    [SerializeField] Rig aimRig;
    public Rig AimRig => aimRig;

    private bool isAim;
    private bool isFire;
    public bool IsAim => isAim;
    [SerializeField] float aimDuration;
    public float AimDuration => aimDuration;
    public void Aim(bool value)
    {
        isAim = false;
        StopAllCoroutines();
        StartCoroutine(Aiming(value));
    }

    public void Attack()
    {
        if (!isAim || isFire) return;
        fireEvent?.Invoke();
        animator.enabled = true;

        animator.Play("Fire" + equipmentName,0,0f);
        isFire = true;
    }
    private void Start()
    {
        EnterItem();
    }
    public override void EnterItem()
    {
        base.EnterItem();
        Debug.Log("들어왔다");
        input.OnAimEvent += Aim;
        input.OnFireEvent += Attack;
        input.OnChangeEvent += StartOffAnimation;
        trigger.AnimationEnd += ChangeNextEquipment;
        animator.Play("On" + equipmentName);
        aimRig.weight = 0f;
        isActive = true;
        isAim = false;
        isFire = false;
    }
    public override void ExitItem()
    {
        base.ExitItem();
        input.OnAimEvent -= Aim;
        input.OnFireEvent -= Attack;
        input.OnChangeEvent -= StartOffAnimation;
        trigger.AnimationEnd -= ChangeNextEquipment;
        nextEquipment.EnterItem();
    }
    private IEnumerator Aiming(bool value)
    {
        float targetWeight = value ? 1f : 0f;
        while (true)
        {
            aimRig.weight = Mathf.Clamp(aimRig.weight + Time.deltaTime / (value ? aimDuration : -aimDuration), 0f, 1f);
            cam.m_Lens.FieldOfView = Mathf.Lerp(60f, 50f, aimRig.weight);
            if (Mathf.Approximately(aimRig.weight, targetWeight))
            {
                aimRig.weight = targetWeight;
                break;
            }
            yield return null;
        }

        if (aimRig.weight > 0.98f) isAim = true;
    }

    public void StartOffAnimation()
    {
        animator.enabled = true;
        animator.Play("Off" + equipmentName);
    }

    public void ChangeNextEquipment()
    {
        if (isFire)
        {
            isFire = false;
            animator.enabled = false;
            return;
        }

        if (isActive)
        {
            isActive = false;
            animator.enabled = false; 
        }
        else
        {
            ExitItem();
        }
    }
}
