using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AccidentManager : MonoBehaviour
{
    [SerializeField] private StageAccidentInfoSO accidentInfo;
    [SerializeField] private float checkStartAccidentInterval;
    private float currentInterval; // test field;
    private List<Accident> activeAccidents;

    private WaitForSeconds wfs;

    [Space]
    public UnityEvent<AccidentType> onStartAccident;

    private void Awake()
    {
        activeAccidents = new List<Accident>();
        wfs = new WaitForSeconds(checkStartAccidentInterval);
    }

    private void Start()
    {
        //InitAccident();

        StartCoroutine(CheckStartAccident());
    }

    private void Update()
    {
        UpdateAccidents();

        currentInterval += Time.deltaTime;
    }

    private void InitAccident()
    {
        for (int i = 0; i < accidentInfo.stageAccidentInfos.Count; i++)
        {
            accidentInfo.stageAccidentInfos[i].accident.InitAccident();
        }
    }

    public void StartAccident(Accident accident)
    {
        Accident accidentInstance = Instantiate(accident, transform);
        accidentInstance.InitAccident();
        accidentInstance.StartAccident();
        activeAccidents.Add(accidentInstance);
        onStartAccident?.Invoke(accidentInstance.AccidentType);
    }

    private void UpdateAccidents()
    {
        for (int i = 0; i < activeAccidents.Count; i++)
        {
            activeAccidents[i].UpdateAccident();
        }
    }

    private IEnumerator CheckStartAccident()
    {
        while (true)
        {
            yield return wfs;

            for (int i = 0; i < accidentInfo.stageAccidentInfos.Count; i++)
            {
                if (Mathf.Abs(accidentInfo.stageAccidentInfos[i].startTime - currentInterval) <= 0.1f)
                {
                    StartAccident(accidentInfo.stageAccidentInfos[i].accident);
                }
            }
        }
    }
}
