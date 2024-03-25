using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GhostShip : MonoBehaviour
{
    [Space]
    private Animator anim;
    private readonly int appearHash = Animator.StringToHash("Appear");
    private readonly int disappearHash = Animator.StringToHash("Disappear");

    [Space]
    [SerializeField] private float maxCannonPower;
    [SerializeField] private float minCannonPower;
    private Cannon[] cannons;
    private int[] cannonIndices;

    [Space]
    [SerializeField] private float chaseDistance;
    private Transform shipTrm;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        cannons = transform.Find("Cannons").GetComponentsInChildren<Cannon>();
        cannonIndices = new int[cannons.Length];
        for (int i = 0; i < cannons.Length; i++)
            cannonIndices[i] = i;
    }

    private void Start()
    {
        shipTrm = Ship.Instance.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Appear(true);
        if (Input.GetKeyDown(KeyCode.D))
            Appear(false);
        if (Input.GetKeyDown(KeyCode.E))
            Fire(5);

        Chase();
    }

    public void Appear(bool value)
    {
        if(value)
            anim.SetTrigger(appearHash);
        else
            anim.SetTrigger(disappearHash);
    }

    public void Fire(int fireCount)
    {
        int shuffleCount = 10;
        int a;
        int b;
        int temp;
        for(int i = 0; i < shuffleCount; i++)
        {
            a = UnityEngine.Random.Range(0, cannonIndices.Length);
            b = UnityEngine.Random.Range(0, cannonIndices.Length);
            
            temp = cannonIndices[a];
            cannonIndices[a] = cannonIndices[b];
            cannonIndices[b] = temp;
        }

        for (int i = 0; i < fireCount; i++)
            cannons[cannonIndices[i]].Fire();
    }

    private void Chase()
    {
        Vector3 targetPos = shipTrm.position + shipTrm.right * chaseDistance;
        float yPos = transform.position.y;
        Vector3 rot = transform.eulerAngles;
        float yRot = shipTrm.eulerAngles.y;

        transform.position = new Vector3(targetPos.x, yPos, targetPos.z);
        transform.rotation = Quaternion.Euler(rot.x, yRot, rot.z);
    }
}
