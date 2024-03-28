using System;
using System.Collections;
using UnityEngine;

public class HumanoidAnimator : MonoBehaviour
{
    [SerializeField] float layerTransitionDuration = 0.5f;
	private Animator animator = null;

    private readonly int isIdleHash = Animator.StringToHash("IsIdle");
    private readonly int isSpawnHash = Animator.StringToHash("IsSpawn");
    private readonly int isWalkHash = Animator.StringToHash("IsWalk");
    private readonly int isAttackHash = Animator.StringToHash("IsAttack");
    private readonly int isHitHash = Animator.StringToHash("IsHit");
    private readonly int isDeadHash = Animator.StringToHash("IsDead");

    private int upperLayerIndex = 0;
    private int lowerLayerIndex = 0;

    public bool ApplyRootMotion { get => animator.applyRootMotion; set => animator.applyRootMotion = value; }

    public event Action OnAnimationStartEvent = null;
    public event Action OnAnimationEvent = null;
    public event Action OnAnimationEndEvent = null;

    private HumanoidAnimationType currentAnimationType = HumanoidAnimationType.Base;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        upperLayerIndex = animator.GetLayerIndex("Upper Layer");
        lowerLayerIndex = animator.GetLayerIndex("Lower Layer");
    }

    public void ToggleIdle(bool active)
    {
        SetLayer(HumanoidAnimationType.Base);
        animator.SetBool(isIdleHash, active);
    }

    public void ToggleSpawn(bool active)
    {
        SetLayer(HumanoidAnimationType.Base);
        animator.SetBool(isSpawnHash, active);
    }

    public void ToggleWalk(bool active)
    {
        SetLayer(HumanoidAnimationType.Base);
        animator.SetBool(isWalkHash, active);
    }

    public void ToggleAttack(bool active)
    {
        SetLayer(HumanoidAnimationType.Upper);
        animator.SetBool(isAttackHash, active);
    }

    public void ToggleHit(bool active)
    {
        SetLayer(HumanoidAnimationType.Lower);
        animator.SetBool(isHitHash, active);
    }

    public void ToggleDead(bool active)
    {
        SetLayer(HumanoidAnimationType.Base);
        animator.SetBool(isDeadHash, active);
    }

    public void SetLayer(HumanoidAnimationType animType)
    {
        if(currentAnimationType == animType)
            return;
        
        currentAnimationType = animType;
        StopAllCoroutines();
        StartCoroutine(SetLayerWeightCoroutine(upperLayerIndex, animType == HumanoidAnimationType.Upper ? 1 : 0));
        StartCoroutine(SetLayerWeightCoroutine(lowerLayerIndex, animType == HumanoidAnimationType.Lower ? 1 : 0));
    }

    public void AnimationStartTrigger()
    {
        OnAnimationStartEvent?.Invoke();
    }

    public void AnimationEventTrigger()
    {
        OnAnimationEvent?.Invoke();
    }

    public void AnimationEndTrigger()
    {
        OnAnimationEndEvent?.Invoke();
    }

    private IEnumerator SetLayerWeightCoroutine(int index, float targetValue)
    {
        float startValue = animator.GetLayerWeight(index);
        float timer = 0f;
        float theta = 0f;

        while(theta < 1f)
        {
            float value = Mathf.Lerp(startValue, targetValue, theta);
            animator.SetLayerWeight(index, value);
            
            timer += Time.deltaTime;
            theta = timer / layerTransitionDuration;

            yield return null;
        }

        animator.SetLayerWeight(index, targetValue);
    }
}
