using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class AimCannon : Cannon, IFocusable, IInteractable
{
    [SerializeField] private ShipInputSO input;

    [SerializeField] private Transform muzzleTrm;

    [SerializeField] private CinemachineVirtualCamera vCam;

    [Space]
    [SerializeField] private Vector2 maxRotate;
    [SerializeField] private Vector2 minRotate;
    [SerializeField] private float rotateSpeed;
    private Vector2 currentRotate;
    private Vector3 originRotate;
    private Vector2 rotateDir;

    private Animator anim;
    private readonly int fireHash = Animator.StringToHash("Fire");

    public GameObject CurrentObject => gameObject;

    private bool selected;

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();
        originRotate = new Vector3(muzzleTrm.eulerAngles.x, transform.eulerAngles.y, 0f);
        currentRotate = Vector3.zero;
        selected = false;
    }

    private void Start()
    {
        input.OnMoveEvent += SetRotateDir;
        input.OnMouseLeftDownEvent += Fire;
        input.OnFEvent += DisableCannon;
    }

    private void Update()
    {
        Rotate();
    }

    private void SetRotateDir(Vector2 input)
    {
        if (!selected)
            return;

        rotateDir = new Vector2(input.x, -input.y);
    }

    private void Rotate()
    {
        currentRotate += rotateDir * rotateSpeed * Time.deltaTime;
        currentRotate.x = Mathf.Clamp(currentRotate.x, minRotate.y, maxRotate.y);
        currentRotate.y = Mathf.Clamp(currentRotate.y, minRotate.x, maxRotate.x);

        muzzleTrm.localRotation = Quaternion.Euler(originRotate.x + currentRotate.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, originRotate.y + currentRotate.x, 0f);
    }

    public override void Fire()
    {
        if (!selected)
            return;

        base.Fire();

        anim.SetTrigger(fireHash);
    }

    private void DisableCannon()
    {
        InputManager.ChangeInputMap(InputMapType.Play);
        vCam.Priority = 0;
        selected = false;
    }

    public void OnFocusBegin(Vector3 point)
    {
        Debug.Log("start focus");
    }

    public void OnFocusEnd()
    {
        Debug.Log("end focus");
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if (!actived)
            return false;
         
        InputManager.ChangeInputMap(InputMapType.Ship);
        vCam.Priority = int.MaxValue;
        selected = true;
        return true;
    }
}
