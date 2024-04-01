using UnityEngine;

[CreateAssetMenu(menuName = "SO/Accident/SkeletonAccidentData")]
public class SkeletonAccidentSO : ScriptableObject
{
	public Transform[] SpawnPositions = null;
    public Transform Container = null;
    public Skeleton SkeletonPrefab = null;
    public float SpawnRadius = 1f;
    public float SpawnRate = 1f;
    public float SpawnYOffset = -0.4f;
    public float SkeletonCount = 10;

    public Vector3 GetSpawnPosition(int index)
    {
        Vector3 origin = SpawnPositions[index].position;
        Vector3 factor = Random.insideUnitCircle;
        float distance = Random.Range(0f, SpawnRadius);
        
        Vector3 position = origin + new Vector3(factor.x, 0, factor.z) * distance;
        // position.y += SpawnYOffset;

        return position;
    }

    public void DrawGizmo(Transform trm, Color color)
    {
        if(trm == null)
            return;

        Gizmos.color = color;
        Gizmos.DrawWireSphere(trm.position, SpawnRadius);
    }
}
