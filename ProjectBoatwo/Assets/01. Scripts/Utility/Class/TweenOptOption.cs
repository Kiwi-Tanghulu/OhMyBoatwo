using UnityEngine;

[System.Serializable]
public class TweenOptOption : OptOption<TweenSO>
{
	public void Init(Transform body)
    {
        PositiveOption = PositiveOption.CreateInstance(body);
        NegativeOption = NegativeOption.CreateInstance(body);
    }
}
