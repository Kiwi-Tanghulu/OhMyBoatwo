using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;

    [Space]
    [SerializeField] private BGMPlayer clearBGMPlayer;
    [SerializeField] private BGMPlayer failBGMPlayer;

    [Space(15f)]
    [SerializeField] TweenOptOption tweenOption = null;

    [Space(15f)]
	[SerializeField] ResultSlot resultSlotPrefab = null;
    [SerializeField] PlayableDirector timelineDirector = null;
    [SerializeField] OptOption<TimelineAsset> timelineOption;

    private HorizontalLayoutGroup containerLayoutGroup = null;
    private List<ResultSlot> slots = new List<ResultSlot>();

    private Transform container = null;
    private TMP_Text resultText = null;

    private void Awake()
    {
        container = transform.Find("Container");
        containerLayoutGroup = container.GetComponent<HorizontalLayoutGroup>();
    
        resultText = transform.Find("ResultText").GetComponent<TMP_Text>();
        
        input.OnAnyKeyEvent += HandleNext;

        tweenOption.Init(transform);
        tweenOption.PositiveOption.OnTweenCompletedEvent += HandleSlotDisplay;
    }

    private void HandleSlotDisplay()
    {
        float delay = 0f;
        slots.ForEach(i => {
            delay = 0.5f;
            StartCoroutine(this.DelayCoroutine(delay, () => {
                i.Display(true);
            }));
        });
    }

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.UI);
        Clear();

        // Init(true, new PlayerInfo());
        // Display(true);
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
            slots.Add(slot);
        }

        StartCoroutine(this.PostponeFrameCoroutine(() => {
            containerLayoutGroup.enabled = false;
            foreach(ResultSlot slot in slots)
                slot.transform.localPosition += Vector3.up * 1080;
        }));

        resultText.text = cleared ? "성공" : "실패";
        BGMPlayer bgmPlayer = cleared ? clearBGMPlayer : failBGMPlayer;
        bgmPlayer.StartBGM();
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
            SceneLoader.LoadSceneAsync("StageScene", true, () => {
                GameManager.Instance.ChangeGameState(GameState.StageSelect);
            });
        });
    }
}
