using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship Instance;

    private List<WaterLeak> leaks;

    private void Awake()
    {
        Instance = this;

        leaks = transform.Find("Leaks").GetComponentsInChildren<WaterLeak>().ToList();
    }

    public void MakeLeak()
    {
        try
        {
            List<WaterLeak> notWorkingLeaks = leaks.FindAll(x => x.isWorking == false);
            int index = UnityEngine.Random.Range(0, notWorkingLeaks.Count);

            notWorkingLeaks[index].Produce();
        }
        catch
        {
            return;
        }
    }
}
