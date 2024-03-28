using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class TweenSO : ScriptableObject
{
    [SerializeField] protected List<TweenParam> tweenParams = new List<TweenParam>();

    private Sequence sequence = null;
    protected Transform body = null;

    public event Action OnTweenCompletedEvent = null;

    public virtual void Init(Transform body)
    {
        this.body = body;
    }

	public void PlayTween(Action callback = null)
    {
        sequence = DOTween.Sequence();
        sequence.OnComplete(() => {
            HandleTweenCompleted();
            callback?.Invoke();
        });

        OnTween(sequence);
    }

    public TweenParam GetParam(int index) => tweenParams[index];

    protected virtual void HandleTweenCompleted()
    {
        OnTweenCompletedEvent?.Invoke();
        sequence?.Kill();
    }

    protected abstract void OnTween(Sequence sequence);
}
