using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

//[Serializable]
//public struct BuoyancyPoint
//{
//    public Vector3 velocity;
//    public bool inWater;
//}

//[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    

    [Space]
    [SerializeField] private float floatingPower;
    [SerializeField] private float floatingOffset;
    [SerializeField] private Transform frontFloatingPoint;
    [SerializeField] private Transform backFloatingPoint;
    [SerializeField] private Transform leftFloatingPoint;
    [SerializeField] private Transform rightFloatingPoint;

    [Space]
    [SerializeField] private float drag;
    [SerializeField] private float angularDrag;
    [SerializeField] private float minAdditiveForce;
    [SerializeField] private float minAngularAdditiveForce;
    [SerializeField] private float angularForceMultiplier;
    [SerializeField] private float middleHeight;
    private Vector3 additiveForce;
    private Vector3 angularAdditiveForce;

    private void Update()
    {
        ApplyDrag();
        Floating();
    }

    public void AddForce(Transform impulseTrm, float power)
    {
        if (impulseTrm == null)
            return;

        Vector3 impulsePoint = impulseTrm.position;
        Vector3 direction = (transform.position - impulseTrm.position).normalized;
        power /= 5f;

        additiveForce = direction * power;
        angularAdditiveForce = new Vector3(direction.z, 0f, direction.x).normalized * power 
            * Mathf.Abs(impulsePoint.y - middleHeight) * angularForceMultiplier;

        if(impulsePoint.y < middleHeight)
            angularAdditiveForce.x *= -1;
        if (impulsePoint.y > middleHeight)
            angularAdditiveForce.z *= -1;
    }

    //public void AddForce(Vector3 impulsePoint, Vector3 direction, float power)
    //{
    //    additiveForce = direction * power;
    //    angularAdditiveForce = new Vector3(direction.z, 0f, direction.x).normalized * power
    //        * Mathf.Abs(impulsePoint.y - middleHeight) * angularForceMultiplier;

    //    if (impulsePoint.y < middleHeight)
    //        angularAdditiveForce.x *= -1;
    //    if (impulsePoint.y > middleHeight)
    //        angularAdditiveForce.z *= -1;
    //}

    private void ApplyDrag()
    {
        if (additiveForce.magnitude < minAdditiveForce)
            additiveForce = Vector3.zero;
        else
            additiveForce = Vector3.Lerp(additiveForce, Vector3.zero, Time.deltaTime * drag);

        if (angularAdditiveForce.magnitude < minAngularAdditiveForce)
            angularAdditiveForce = Vector3.zero;
        else
            angularAdditiveForce = Vector3.Lerp(angularAdditiveForce, Vector3.zero, Time.deltaTime * angularDrag);
    }
    
    private void Floating()
    {
        float waterHeight = WaterManager.Instance.GetWaveHeight(transform.position) + floatingOffset;
        float y = Mathf.Lerp(waterHeight, transform.position.y, Time.deltaTime * floatingPower);
        float dot;
        float singleAngle;
        Vector3 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        //position
        pos.y = y;
        pos.x += additiveForce.x * Time.deltaTime;
        pos.z += additiveForce.z * Time.deltaTime;
        transform.position = pos;

        if(angularAdditiveForce.magnitude > minAngularAdditiveForce)
        {
            angle.x = angularAdditiveForce.x;
            angle.z = angularAdditiveForce.z;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle),
                Time.deltaTime);
        }
        else
        {
            //x rotation
            Vector3 frontVector = new Vector3(frontFloatingPoint.position.x, WaterManager.Instance.GetWaveHeight(frontFloatingPoint.position), frontFloatingPoint.position.z);
            Vector3 backVector = new Vector3(backFloatingPoint.position.x, WaterManager.Instance.GetWaveHeight(backFloatingPoint.position), backFloatingPoint.position.z);
            Vector3 forwardDir = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
            Vector3 hypotenuse = (frontVector - backVector).normalized;
            dot = Mathf.Clamp(Vector3.Dot(hypotenuse, forwardDir), -1f, 1f);
            try
            {
                singleAngle = Mathf.Abs(Mathf.Rad2Deg * Mathf.Acos(dot));
                singleAngle *= frontVector.y < backVector.y ? 1 : -1;
            }
            catch
            {
                singleAngle = angle.x;
            }

            angle.x = singleAngle + angularAdditiveForce.x;
            #region exception handling
            //if (!(forwardDir == Vector3.zero || hypotenuse == Vector3.zero))
            //{
            //    dot = Mathf.Abs(Mathf.Rad2Deg * ;
            //    angle.x = frontVector.y < backVector.y ? dot : -dot;
            //}
            #endregion

            //z rotation
            Vector3 leftVector = new Vector3(leftFloatingPoint.position.x, WaterManager.Instance.GetWaveHeight(leftFloatingPoint.position), leftFloatingPoint.position.z);
            Vector3 rightVector = new Vector3(rightFloatingPoint.position.x, WaterManager.Instance.GetWaveHeight(rightFloatingPoint.position), rightFloatingPoint.position.z);
            Vector3 rightDir = new Vector3(transform.right.x, 0f, transform.right.z).normalized;
            hypotenuse = (rightVector - leftVector).normalized;
            dot = Mathf.Clamp(Vector3.Dot(hypotenuse, rightDir), -1f, 1f);
            try
            {
                singleAngle = Mathf.Abs(Mathf.Rad2Deg * Mathf.Acos(dot));
                singleAngle *= leftVector.y < rightVector.y ? 1 : -1;
            }
            catch
            {
                singleAngle = angle.z;
            }

            angle.z = singleAngle + angularAdditiveForce.z;
            angle.y = transform.eulerAngles.y;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle), Time.deltaTime * floatingPower);
        }

        #region exception handling
        //if (!(rightDir == Vector3.zero || hypotenuse == Vector3.zero))
        //{
        //    dot = Mathf.Abs(Mathf.Rad2Deg * Mathf.Acos(Mathf.Clamp(Vector3.Dot(hypotenuse, rightDir), -1f, 1f)));
        //    angle.z = leftVector.y < rightVector.y ? dot : -dot;
        //}
        #endregion
    }
    
    public void SetFloatingOffset(float value)
    {
        DOTween.To(() => floatingOffset, x => floatingOffset = x, value, 1f);
    }
    public void SetFloatingPower(float value) => floatingPower = value;
}