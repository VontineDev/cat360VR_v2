using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trggggggggg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print($"Unity : {this.gameObject.name} OnTrigger {other.name}, {other.tag}");
        if(other.tag=="Hand")
        {
            print($"Unity : Cat TriggerEnter Hand");
        }
    }
}
