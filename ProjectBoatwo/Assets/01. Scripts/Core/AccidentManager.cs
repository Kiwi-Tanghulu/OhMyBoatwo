using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AccidentManager : MonoBehaviour
{
    public static AccidentManager Instance;

    [SerializeField] private StageAccidentInfoSO accidentInfo;
    [SerializeField] private float checkStartAccidentInterval;
    private float currentInterval; // test field;
    private List<Accident> activeAccidents;
    private List<StageAccidentInfo> allAccidentInfos;

    private WaitForSeconds wfs;

    [Space]
    public UnityEvent<AccidentType> onStartAccident;

    private void Awake()
    {
        Instance = this;

        activeAccidents = new List<Accident>();
        wfs = new WaitForSeconds(checkStartAccidentInterval);
    }

    private void Start()
    {
        InitAccident();

        StartCoroutine(CheckStartAccident());
    }

    private void Update()
    {
        UpdateAccidents();

        currentInterval += Time.deltaTime;
    }

    private void InitAccident()
    {
        allAccidentInfos = new List<StageAccidentInfo>();

        foreach(StageAccidentInfo accidentInfo in accidentInfo.stageAccidentInfos)
        {
            StageAccidentInfo info = new StageAccidentInfo();
            info.startTime = accidentInfo.startTime;
            info.accident = Instantiate(accidentInfo.accident, transform);
            info.accident.InitAccident();
            info.accident.gameObject.SetActive(false);
            allAccidentInfos.Add(info);
        }
    }

    public void StartAccident(Accident accident)
    {
        if (accident.isActive)
            return;

        accident.gameObject.SetActive(true);
        accident.StartAccident();
        activeAccidents.Add(accident);
        onStartAccident?.Invoke(accident.AccidentType);
    }

    private void UpdateAccidents()
    {
        for (int i = 0; i < activeAccidents.Count; i++)
        {
            activeAccidents[i].UpdateAccident();
        }
    }

    public void EndAccident(Accident accident)
    {
        activeAccidents.Remove(accident);
    }

    private IEnumerator CheckStartAccident()
    {
        while (true)
        {
            yield return wfs;

            for (int i = 0; i < allAccidentInfos.Count; i++)
            {
                if (Mathf.Abs(allAccidentInfos[i].startTime - currentInterval) <= 0.1f)
                {
                    StartAccident(allAccidentInfos[i].accident);
                }
            }
        }
    }
}
