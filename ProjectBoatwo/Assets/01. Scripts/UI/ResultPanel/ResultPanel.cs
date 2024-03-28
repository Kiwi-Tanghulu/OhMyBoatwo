using System.Collections.Generic;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
	[SerializeField] ResultSlot resultSlotPrefab = null;
    private Transform container = null;

    private void Awake()
    {
        container = transform.Find("Container");
    }

    public void Init(List<PlayerInfo> playerInfos)
    {
        playerInfos.ForEach(i => {
            ResultSlot slot = Instantiate(resultSlotPrefab, container);
            slot.Init(i);
            slot.Display(true);
        });
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
}
