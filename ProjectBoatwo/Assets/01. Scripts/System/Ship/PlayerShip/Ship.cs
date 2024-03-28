using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship Instance { get; private set; }

    private List<WaterLeak> leaks;
    public List<WaterLeak> Leaks => leaks;

    private void Awake()
    {
        Instance = this;

        leaks = transform.Find("Leaks").GetComponentsInChildren<WaterLeak>().ToList();
    }

    public void MakeLeak()
    {
        List<WaterLeak> notWorkingLeaks = leaks.FindAll(x => x.isWorking == false);

        if (notWorkingLeaks.Count == 0)
            return;

        int index = UnityEngine.Random.Range(0, notWorkingLeaks.Count);

        notWorkingLeaks[index].Produce();
    }
}
