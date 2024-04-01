using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawnPositionSelector : MonoBehaviour
{
	[SerializeField] SkeletonAccidentSO accidentData = null;
    [SerializeField] Transform[] spawnPositions = null;


    public void SetParam()
    {
        accidentData.Container = transform.Find("Container");
        accidentData.SpawnPositions = spawnPositions;
    }
}
