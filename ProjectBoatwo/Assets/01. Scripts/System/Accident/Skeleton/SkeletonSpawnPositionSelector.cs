using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawnPositionSelector : MonoBehaviour
{
	[SerializeField] SkeletonAccidentSO accidentData = null;
    [SerializeField] List<Transform> spawnPositions = null;

    private void Awake()
    {
        accidentData.Container = transform.Find("Container");
    }

    private void Start()
    {
        accidentData.SpawnPositions = spawnPositions.ToArray();
    }
}
