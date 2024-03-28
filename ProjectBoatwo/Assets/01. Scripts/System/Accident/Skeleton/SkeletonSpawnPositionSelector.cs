using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawnPositionSelector : MonoBehaviour
{
	[SerializeField] SkeletonAccidentSO accidentData = null;
    [SerializeField] List<Transform> spawnPositions = null;

    private float timer = 0f;
    private float changeTime = 10f;

    private void Awake()
    {
        accidentData.Container = transform.Find("Container");
    }

    private void Start()
    {
        DecideSpawnPosition();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > changeTime)
        {
            DecideSpawnPosition();
            timer = 0f;
        }
    }

    private void DecideSpawnPosition()
    {
        accidentData.SpawnPosition = spawnPositions.PickRandom();
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(accidentData == null)
            return;
        
        foreach(Transform trm in spawnPositions)
            accidentData.DrawGizmo(trm, Color.red);
        accidentData.DrawGizmo(accidentData.SpawnPosition, Color.green);
    }
    #endif
}
