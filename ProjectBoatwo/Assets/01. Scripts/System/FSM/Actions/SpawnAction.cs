using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class RisingSpawnAction : FSMAction
{
	[SerializeField] float spawningDuration = 2f;
    [SerializeField] float risingDistance = 1f;
    [SerializeField] Ease risingEase = Ease.InSine;

    private NavMovement movement = null;
    public UnityEvent OnSpawnFinishedEvent = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        movement = brain.GetComponent<NavMovement>();
    }

    public override void EnterState()
    {
        base.EnterState();

        // movement.SetActive(false);
        brain.transform.DOLocalMoveY(
            brain.transform.localPosition.y + risingDistance, 
            spawningDuration
        )
        .SetEase(risingEase)
        .OnComplete(HandleSpawnFinished);
    }

    private void HandleSpawnFinished()
    {
        movement.SetActive(true);
        OnSpawnFinishedEvent?.Invoke();
    }
}
