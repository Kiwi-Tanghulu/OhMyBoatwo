using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private PlayInputSO input;
    //public PlayInputSO Input => input;

    [SerializeField] private float speedMultiplier;

    [SerializeField] private float runSpeed;
    public float RunSpeed => runSpeed;
    [SerializeField] private float walkSpeed;
    public float WalkSpeed => walkSpeed;
    [SerializeField] private float swimSpeed;
    public float SwimSpeed => swimSpeed;
    [SerializeField] private float climSpeed;
    public float ClimSpeed => climbSpeed;

    private float currentMaxSpeed;
    public float CurrentMaxSpeed => currentMaxSpeed;
    private float currentSpeed;
    public float CurrentSpeed => currentSpeed;

    [SerializeField] private float climbSpeed;
    public float ClimbSpeed => climbSpeed;

    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;
    public Vector3 MoveDir { get; private set; }
    private Vector3 lastMoveDir;

    private bool isJump;
    public bool IsJump { get => isJump; set => isJump = value; }

    #region LadderVariable
    public Vector3 LadderUpPos { get; private set; }
    public Vector3 LadderDownPos { get; private set; }
    public Vector3 UpArrivePos { get; private set; }
    public Vector3 DownArrivePos { get; private set; }
    #endregion

    private Rigidbody rigid;
    public Rigidbody Rigid => rigid;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider groundCheckCol;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        //input.OnMoveEvent += SetMoveDirection;
        isJump = false;
    }
    private void OnDestroy()
    {
        //input.OnMoveEvent -= SetMoveDirection;
    }
    public void SetCurrentMaxSpeed(float _currentMaxSpeed)
    {
        currentMaxSpeed = _currentMaxSpeed;
    }
    public void SpeedCalculate()
    {
        if (currentSpeed > currentMaxSpeed)
            currentSpeed += -speedMultiplier * Time.deltaTime;
        else
            currentSpeed += (MoveDir.sqrMagnitude > 0.1f ? speedMultiplier : -speedMultiplier) * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, runSpeed);
    }
    public void ResetSpeed()
    {
        currentSpeed = 0f;
    }
    public void Move()
    {
        Vector3 moveDir = transform.rotation * lastMoveDir;
        if (IsOnSlope() && IsGround() && !isJump)
        {
            moveDir = AdjustDirectionToSlope(moveDir);
            rigid.useGravity = false;
            rigid.velocity = Vector3.zero;
        }
        else
        {
            rigid.useGravity = true;
        }
        rigid.MovePosition(transform.position + moveDir * currentSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void SetMoveDirection(Vector2 value)
    {
        MoveDir = new Vector3(value.x, 0f, value.y);
        if (value.sqrMagnitude > 0.1f)
            lastMoveDir = MoveDir;
    }
    public void Teleport(Vector3 teleportPos)
    {
        transform.position = teleportPos;
    }
    #region Clim

    public void SetClimingPos(Vector3 ladderUp, Vector3 ladderDown, Vector3 upArrive, Vector3 downArrive, Vector3 teleportPos)
    {
        LadderUpPos = ladderUp;
        LadderDownPos = ladderDown;
        UpArrivePos = upArrive;
        DownArrivePos = downArrive;
        Teleport(teleportPos);
    }
    #endregion
    public bool IsGround()
    {
        return Physics.OverlapBox(groundCheckCol.transform.position + groundCheckCol.center, groundCheckCol.size / 2, Quaternion.identity, groundLayer).Length > 0;
    }


    private RaycastHit slopeHit;
    [SerializeField] private float maxSlopeAngle;
    [SerializeField] private float slopeRayDistance;

    #region Slope
    private bool IsOnSlope()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        if (Physics.Raycast(ray, out slopeHit, slopeRayDistance, groundLayer))
        {
            var angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle != 0f && angle < maxSlopeAngle;
        }
        return false;
    }

    private Vector3 AdjustDirectionToSlope(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.down * slopeRayDistance);
    }
}
