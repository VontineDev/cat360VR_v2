using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print($"OnTriggerEnter, Collider : {other.gameObject.name}");
    }
}
