using System.Collections;
using Cinemachine;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
	[SerializeField] Transform defaultFollowTarget = null;
	[SerializeField] float defaultDistance = 30f;

    private CinemachineVirtualCamera stageCam = null;
    private CinemachineFramingTransposer framingTransposer = null;

    public float Distance { 
        get => framingTransposer.m_CameraDistance; 
        private set => framingTransposer.m_CameraDistance = value; 
    }
    
    private void Awake()
    {
        stageCam = GetComponent<CinemachineVirtualCamera>();
        framingTransposer = stageCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    public void SetFollowTarget(Transform target)
    {
        stageCam.Follow = target;
    }

    public void ResetFollowTarget()
    {
        stageCam.Follow = defaultFollowTarget;
    }

    public void ResetDistance()
    {
        Distance = defaultDistance;
    }

    public void SetDistance(float value, float duration)
    {
        StopAllCoroutines();

        if(duration == 0f)
            Distance = value;
        else
            StartCoroutine(SetDistanceCoroutine(value, duration));
    }

    private IEnumerator SetDistanceCoroutine(float targetValue, float duration)
    {
        float startValue = Distance;
        float timer = 0f;
        float theta = 0f;

        while(theta < 1f)
        {
            Distance = Mathf.Lerp(startValue, targetValue, theta);
            
            theta = timer / duration;
            timer += Time.deltaTime;
            yield return null;
        }

        Distance = targetValue;
    }
}
