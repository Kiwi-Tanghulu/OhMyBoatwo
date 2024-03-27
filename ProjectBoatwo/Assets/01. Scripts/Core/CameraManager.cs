using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private Camera mainCam;
    private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        mainCam = Camera.main;
        impulseSource = mainCam.GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeCam(Vector3 velocity, float duration, float force)
    {
        impulseSource.m_DefaultVelocity = velocity;
        impulseSource.m_ImpulseDefinition.m_ImpulseDuration = duration;
        impulseSource.GenerateImpulseWithForce(force);
    }
}
