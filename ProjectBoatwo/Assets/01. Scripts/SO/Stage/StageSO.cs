using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageSO : ScriptableObject
{
	public Stage StagePrefab = null;
    public float PlayTime = 60f;
    public bool IsCleared = false;
}
