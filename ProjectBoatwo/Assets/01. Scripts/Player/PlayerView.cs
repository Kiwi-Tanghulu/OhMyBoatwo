using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayInputSO input;
    [SerializeField] private CinemachineVirtualCamera playerCam;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private bool inverseX;
    [SerializeField] private bool inverseY;

    private float cameraAngle;

    private bool isActive;

    private void Awake()
    {
        input.OnMouseDeltaEvent += PlayerRotate;
        input.OnMouseDeltaEvent += CameraRotate;
    }

    private void Start()
    {
        isActive = true;
    }

    private void OnDestroy()
    {
        input.OnMouseDeltaEvent -= PlayerRotate;
        input.OnMouseDeltaEvent -= CameraRotate;
    }

    private void PlayerRotate(Vector2 mouseDelta)
    {
        if (!isActive)
            return;

        float rotateValue = mouseDelta.x * rotateSpeed;

        if (inverseX)
            rotateValue *= -1;

        transform.Rotate(rotateValue * Vector3.up);
    }

    private void CameraRotate(Vector2 mouseDelta)
    {
        if (!isActive)
            return;

        float rotateValue = mouseDelta.y * rotateSpeed;

        if (inverseY)
            rotateValue *= -1;
        cameraAngle += rotateValue;
        cameraAngle = Mathf.Clamp(cameraAngle, minY, maxY);

        playerCam.transform.localRotation = Quaternion.Euler(cameraAngle, 0f, 0f);
    }

    public void SetActive(bool value)
    {
        isActive = value;
    }
}
