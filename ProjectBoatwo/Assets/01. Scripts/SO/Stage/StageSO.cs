using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageSO : ScriptableObject
{
	public Stage StagePrefab = null;
    public Sprite StageImage = null;
    public string StageName = "";
    
    [Space(15f)]
    public float PlayTime = 60f;
    public float PlayingTime = 0f;

    [Space(15f)]
    public int EarnedStar = 0;
}
