using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    public static SingletonExample Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void SingltoneMethod()
    {
        print($"Called singleton Method");
    }


}
