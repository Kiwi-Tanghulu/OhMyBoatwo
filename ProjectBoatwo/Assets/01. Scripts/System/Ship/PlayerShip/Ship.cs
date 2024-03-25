using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship Instance;

    private void Awake()
    {
        Instance = this;
    }
}
