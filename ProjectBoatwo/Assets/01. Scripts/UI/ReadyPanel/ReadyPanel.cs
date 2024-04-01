using TMPro;
using UnityEngine;

public class ReadyPanel : MonoBehaviour
{
	private TMP_Text countingText = null;

    private float timer = 0f;
    private bool counting = false;

    private void Awake()
    {
        countingText = transform.Find("CountingText").GetComponent<TMP_Text>();

        GameManager.Instance.OnGameStateChangedEvent += HandleGameStateChanged;
    }

    private void Update()
    {
        if(counting == false)
            return;

        timer -= Time.deltaTime;
        // countingText.text = Mathf.CeilToInt(timer).ToString("0");

        if(timer < 0)
        {
            counting = false;
            StageManager.Instance.StartStage();
            Display(false);
        }
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private void HandleGameStateChanged(GameState state)
    {
        counting = state == GameState.Ready;
        if(counting)
            timer = DEFINE.StageReadyCount;
    }
}
