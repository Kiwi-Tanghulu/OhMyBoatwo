using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;

    private Vector3 moveDir;

    public void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void SetMoveDir(Vector3 dir)
    {
        moveDir = dir.normalized;
        try
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.x, dir.z);
            //float time = angle / turnSpeed;
            Vector3 currentRotation = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, angle, currentRotation.z));
            //transform.DORotate(new Vector3(currentRotation.x, angle, currentRotation.z), time).SetEase(Ease.Linear);
        }
        catch
        {
            Debug.LogError($"do not rotate this vector : {dir}");
        }
    }
}
