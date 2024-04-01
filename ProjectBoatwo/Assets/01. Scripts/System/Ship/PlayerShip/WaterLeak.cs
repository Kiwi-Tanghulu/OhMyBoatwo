using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaterLeak : MonoBehaviour, IFocusable, IInteractable
{
    public UnityEvent onProduced;
    public event Action OnStartRepairing;
    public event Action<float> OnRepairing;
    public event Action<bool> OnEndRepairing;

    [SerializeField] private float repairTime;
    private float currentRepairTime;

    //private GameObject focusedObj;

    private GameObject repairer;

    public bool isWorking { get; private set; }

    public GameObject CurrentObject => gameObject;

    private void Awake()
    {
        //focusedObj = transform.Find("FocusedVisual").gameObject;
    }

    private void Start()
    {
        gameObject.SetActive(false);    
        isWorking = false;
    }

    public void Produce()
    {
        if (isWorking)
            return;
        
        isWorking = true;
        gameObject.SetActive(true);

        onProduced?.Invoke();
    }

    public void EndRepair(bool isSuccess)
    {
        OnEndRepairing?.Invoke(isSuccess);

        if (repairer.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
            movement.enabled = true;
        if (repairer.TryGetComponent<PlayerView>(out PlayerView view))
            view.SetActive(true);

        currentRepairTime = 0f;
        isWorking = !isSuccess;
        gameObject.SetActive(!isSuccess);
    }

    public void OnFocusBegin(Vector3 point)
    {
        Debug.Log("focus");
        //focusedObj.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        Debug.Log("unfocus");
        //focusedObj.gameObject.SetActive(false);
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if (!actived)
        {
            StopAllCoroutines();

            EndRepair(false);

            return false;
        }
        else
        {
            repairer = performer.gameObject;

            if (repairer.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
                movement.enabled = false;
            if (repairer.TryGetComponent<PlayerView>(out PlayerView view))
                view.SetActive(false);

            OnStartRepairing?.Invoke();

            StartCoroutine(Reparing());

            return true;
        }
    }

    private IEnumerator Reparing()
    {
        while(currentRepairTime < repairTime)
        {
            currentRepairTime += Time.deltaTime;
            OnRepairing?.Invoke(currentRepairTime / repairTime);

            yield return null;
        }

        Debug.Log(123);
        EndRepair(true);
    }
}
