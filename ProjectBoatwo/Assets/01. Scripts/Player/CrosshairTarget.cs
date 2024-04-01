using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        ray.origin = cam.transform.position;
        ray.direction = cam.transform.forward;
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);
        transform.position = hitInfo.point;
    }
}
