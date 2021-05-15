using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCat : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    private void Update()
    {
        Vector3 f = transform.TransformDirection(Vector3.forward * 1000);
    Debug.DrawRay(transform.position,f, Color.green) ;
        if(Physics.Raycast(transform.position,f,out hit))
        {
            Debug.Log("고양이다");

        }
                }
}
