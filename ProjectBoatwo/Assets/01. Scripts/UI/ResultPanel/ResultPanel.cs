using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
	[SerializeField] ResultSlot resultSlotPrefab = null;
    [SerializeField] PlayableDirector timelineDirector = null;
    [SerializeField] OptOption<TimelineAsset> timelineOption;

    private Transform container = null;
    private TMP_Text resultText = null;

    private void Awake()
    {
        container = transform.Find("Container");
        resultText = transform.Find("ResultText").GetComponent<TMP_Text>();
        
        input.OnAnyKeyEvent += HandleNext;
    }

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.UI);

        Clear();
        Display(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Init(true);
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
            slot.Display(true);
        }

        resultText.text = cleared ? "CLEAR" : "FAIL";
        timelineDirector.playableAsset = timelineOption.GetOption(cleared);
        timelineDirector.Play();
    }

    public void Clear()
    {
        foreach(Transform slot in container)
            Destroy(slot.gameObject);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private void HandleNext()
    {
        SceneLoader.LoadSceneAsync("StageScene");
    }
}
