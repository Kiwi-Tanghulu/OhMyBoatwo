using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] PlayerInfoSlot infoSlotPrefab = null;

	private List<PlayerInfoSlot> slots = new List<PlayerInfoSlot>();
    private Transform container = null;

    private void Awake()
    {
        container = transform;
        Clear();
    }

    // private void Start()
    // {
    //     SetCapacity(1);
    //     PlayerInfo info = new PlayerInfo() {Nickname = "SEH00N", PlayerColor = Color.green, PlayerNumber = 0};
    //     CreateSlot(info);
    // }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetCapacity(int capacity)
    {
        slots.AddRange(new PlayerInfoSlot[capacity]);
    }

    public void CreateSlot(PlayerInfo info)
    {
        PlayerInfoSlot slot = Instantiate(infoSlotPrefab, container);
        slot.Init(info);

        slots[info.PlayerNumber] = slot;
    }

    public void Clear()
    {
        foreach(Transform slot in container)
            Destroy(slot.gameObject);
        slots.Clear();
    }

    public PlayerInfoSlot GetSlot(int index)
    {
        return slots[index];
    }
}
