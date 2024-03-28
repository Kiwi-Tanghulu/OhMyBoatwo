using System;
using UnityEngine;

public class DetectTargetAction : FSMAction
{
    [SerializeField] DetectTargetParams param = null;
    private Collider[] container = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);
        container = new Collider[4];
    }

    public override void UpdateState()
    {
        base.UpdateState();
        param.Target = DetectTarget();
    }

    private Transform DetectTarget()
    {
        int detected = Physics.OverlapSphereNonAlloc(transform.position, param.Radius, container, param.TargetLayer);
        
        if(detected <= 0)
            return null;

        if (detected > 1)
        {
            Array.Sort(container, (a, b) => {
                float distanceA = a == null ? float.MaxValue : (transform.position - a.transform.position).sqrMagnitude;
                float distanceB = b == null ? float.MaxValue : (transform.position - b.transform.position).sqrMagnitude;

                if (distanceA == distanceB)
                    return 0;
                else if (distanceA > distanceB)
                    return 1;
                else return -1;
            });
        }

        return container[0].transform;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(param == null)
            return;
        
        param.DrawGizmo(transform);
    }
    #endif
}
