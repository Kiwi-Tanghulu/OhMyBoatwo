using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AccidentManager : MonoBehaviour
{
    public static AccidentManager Instance;

    [SerializeField] private StageAccidentInfoSO accidentInfo;
    [SerializeField] private float checkStartAccidentInterval;
    private float currentInterval;
    private List<Accident> activeAccidents;
    private List<StageAccidentInfo> allAccidentInfos;

    [Space]
    public UnityEvent<AccidentType> onStartAccident;

    private NoticePanel noticePanel;

    private void Awake()
    {
        Instance = this;

        activeAccidents = new List<Accident>();
    }

    private void Start()
    {
        InitAccident();

        noticePanel = GameObject.FindObjectOfType<NoticePanel>();
        Debug.Log(noticePanel);
    }

    private void Update()
    {
        UpdateAccidents();

        currentInterval += Time.deltaTime;

        for (int i = 0; i < allAccidentInfos.Count; i++)
        {
            if (Mathf.Abs(allAccidentInfos[i].startTime - currentInterval) <= 0.1f)
            {
                StartAccident(allAccidentInfos[i].accident);
            }
        }
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
        noticePanel.SetText(accident.Info.StartNoticeText);
        onStartAccident?.Invoke(accident.Info.AccidentType);
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
}
