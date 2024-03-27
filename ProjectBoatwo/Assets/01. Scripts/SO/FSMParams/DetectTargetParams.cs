using UnityEngine;

[CreateAssetMenu(menuName = "SO/FSMParams/DetectTarget")]
public class DetectTargetParams : ScriptableObject
{
	public float Radius = 10f;
    public LayerMask TargetLayer = 0;
    public Transform Target = null;

    public void DrawGizmo(Transform trm)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(trm.position, Radius);
    }
}
