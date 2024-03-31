using UnityEngine;

public class GhostShip : Accident
{
    [Space]
    private Animator anim;
    private readonly int appearHash = Animator.StringToHash("Appear");
    private readonly int disappearHash = Animator.StringToHash("Disappear");

    [Space]
    [SerializeField] private float maxCannonFireDelay;
    [SerializeField] private float minCannonFireDelay;
    private float cannonfireDelay;
    private float currentCannonfireDelay;
    [SerializeField] private int maxFireCount;
    [SerializeField] private int minFireCount;
    [SerializeField] private int maxFireAngle;
    [SerializeField] private int minFireAngle;
    private Cannon[] cannons;
    private int[] cannonIndices;

    [Space]
    [SerializeField] private float chaseDistance;
    [SerializeField] private float moveSpeed;
    private Transform shipTrm;

    private bool completeAppear;

    private MeshCollider col;

    public override void InitAccident()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<MeshCollider>();

        cannons = transform.Find("Cannons").GetComponentsInChildren<Cannon>();
        cannonIndices = new int[cannons.Length];
        for (int i = 0; i < cannons.Length; i++)
            cannonIndices[i] = i;

        shipTrm = Ship.Instance.transform;

        completeAppear = false;
    }

    public override void StartAccident()
    {
        base.StartAccident();

        Appear(true);

        col.enabled = false;
        transform.position = shipTrm.position + shipTrm.right * chaseDistance;
        cannonfireDelay = UnityEngine.Random.Range(minCannonFireDelay, maxCannonFireDelay);
        currentCannonfireDelay = 0f;
    }

    public override void UpdateAccident()
    {
        Chase();

        if(completeAppear)
        {
            currentCannonfireDelay += Time.deltaTime;
            if (currentCannonfireDelay > cannonfireDelay)
                Fire();
        }
    }

    public override void EndAccident()
    {
        AccidentManager.Instance.EndAccident(this);
        isActive = false;
        completeAppear = false;
        col.enabled = false;
        Appear(false);
    }

    public void Appear(bool value)
    {
        if(value)
            anim.SetTrigger(appearHash);
        else
            anim.SetTrigger(disappearHash);
    }

    public void Fire()
    {
        int shuffleCount = 10;
        int a;
        int b;
        int temp;
        for (int i = 0; i < shuffleCount; i++)
        {
            a = UnityEngine.Random.Range(0, cannonIndices.Length);
            b = UnityEngine.Random.Range(0, cannonIndices.Length);

            temp = cannonIndices[a];
            cannonIndices[a] = cannonIndices[b];
            cannonIndices[b] = temp;
        }

        int fireCount = UnityEngine.Random.Range(minFireCount, maxFireCount + 1);
        for (int i = 0; i < fireCount; i++)
        {
            Cannon cannon = cannons[cannonIndices[i]];
            
            cannon.Fire(Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(minFireAngle, maxFireAngle)) * cannon.FirePoint.forward);
        }

        cannonfireDelay = UnityEngine.Random.Range(minCannonFireDelay, maxCannonFireDelay);
        currentCannonfireDelay = 0f;
    }

    private void Chase()
    {
        Vector3 targetPos = shipTrm.position + shipTrm.right * chaseDistance;
        Vector3 dir = (targetPos - transform.position).normalized;
        dir.y = 0f;

        transform.position += dir * moveSpeed * Time.deltaTime;

        #region
        //float yPos = transform.position.y;
        //Vector3 rot = transform.eulerAngles;
        //float yRot = shipTrm.eulerAngles.y;

        //transform.position = new Vector3(targetPos.x, yPos, targetPos.z);
        //transform.rotation = Quaternion.Euler(rot.x, yRot, rot.z);
        #endregion
    }

    #region animation methods
    public void EndAppear()
    {
        completeAppear = true;
        col.enabled = true;
    }
    public void EndDisappear()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
