using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print($"OnTriggerEnter, Collider : {other.gameObject.name}");

        if (other.tag == "Hand")
        {
            DelegateManager.Instance.TouchCompleteOperation();
        }
    }
}
