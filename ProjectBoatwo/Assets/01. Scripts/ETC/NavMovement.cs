using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
	private NavMeshAgent navAgent = null;

    public float Speed { get => navAgent.speed; set => navAgent.speed = value; }
    public float Accel { get => navAgent.acceleration; set => navAgent.acceleration = value; }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetActive(false);
    }

    public void SetDestination(Vector3 destination) => navAgent.SetDestination(destination);
    public void StopImmediately() => SetDestination(transform.position);
    public void ActiveAutoRotation(bool active) => navAgent.updateRotation = active;

    public void SetActive(bool active)
    {
        if(active)
        {
            navAgent.enabled = active;
            navAgent.isStopped = !active;
        }
        else
        {
            navAgent.isStopped = !active;
            navAgent.enabled = active;
        }

        // navAgent.isStopped = !active;
        // navAgent.enabled = active;
    }

}
