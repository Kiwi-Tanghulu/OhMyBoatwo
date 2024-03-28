using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
    [SerializeField] OptOption<TweenSO> tweenOption = null;

    [Space(15f)]
	[SerializeField] ResultSlot resultSlotPrefab = null;
    [SerializeField] PlayableDirector timelineDirector = null;
    [SerializeField] OptOption<TimelineAsset> timelineOption;

    private List<ResultSlot> slots = new List<ResultSlot>();

    private Transform container = null;
    private TMP_Text resultText = null;

    private void Awake()
    {
        container = transform.Find("Container");
        resultText = transform.Find("ResultText").GetComponent<TMP_Text>();
        
        input.OnAnyKeyEvent += HandleNext;

        tweenOption.PositiveOption.Init(transform);
        tweenOption.PositiveOption.OnTweenCompletedEvent += HandleSlotDisplay;
        tweenOption.NegativeOption.Init(transform);
    }

    private void HandleSlotDisplay()
    {
        float delay = 0f;
        slots.ForEach(i => {
            delay = 0.25f;
            StartCoroutine(this.DelayCoroutine(delay, () => {
                i.Display(true, true);
                i.Display(true);
            }));
        });
    }

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.UI);
        Clear();

        Init(true, new PlayerInfo());
        Display(true);
    }

    private void OnDestroy()
    {
        input.OnAnyKeyEvent -= HandleNext;
    }

    public void Init(bool cleared, params PlayerInfo[] playerInfos)
    {
        foreach(PlayerInfo info in playerInfos)
        {
            ResultSlot slot = Instantiate(resultSlotPrefab, container);
            slot.Init(info);
            slot.Display(false, true);
            slots.Add(slot);
        }

        resultText.text = cleared ? "CLEAR" : "FAIL";
        timelineDirector.playableAsset = timelineOption.GetOption(cleared);
        timelineDirector.Play();
    }

    public void Clear()
    {
        foreach(Transform slot in container)
            Destroy(slot.gameObject);
        slots.Clear();
    }

    public void Display(bool active)
    {
        tweenOption.GetOption(active).PlayTween();
    }

    private void HandleNext()
    {
        tweenOption.GetOption(false).PlayTween(() => {
            SceneLoader.LoadSceneAsync("StageScene");
        });
    }
}
