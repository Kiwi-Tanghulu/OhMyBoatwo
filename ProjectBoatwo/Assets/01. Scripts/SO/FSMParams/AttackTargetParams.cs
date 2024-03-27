using UnityEngine;

[CreateAssetMenu(menuName = "SO/FSMParams/AttackTarget")]
public class AttackTargetParams : ScriptableObject
{
	public float AttackRange = 1f;
    public float AttackCooldown = 0.5f;
    public float DashDistance = 0.25f;
    public int Damage = 10;
    public bool IsCooldown = false;

    public void DrawGizmo(Transform trm)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(trm.position, AttackRange);
    }
}
