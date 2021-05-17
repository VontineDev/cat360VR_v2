using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCat : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;

    bool isFound; //Found Cat?
    private void Start()
    {
        DelegateManager.Instance.SearchCatOperate += Instance_SearchCatOperate;
        DelegateManager.Instance.WorldChangeOperate += Instance_WorldChangeOperate;
        DelegateManager.Instance.ComeCatOperate += Instance_ComeCatOperate;
    }

    //마지막월드에서는 고양이를 이미 찾은것으로 본다.
    private void Instance_ComeCatOperate()
    {
        isFound = true;
    }

    private void Instance_WorldChangeOperate()
    {
        //월드가 바뀌었으므로 고양이는 Not Found
        isFound = false;
        Instance_SearchCatOperate();
    }

    
    private void Instance_SearchCatOperate()
    {
        print("Instance_SearchCatOperate");

        StartCoroutine(SearchCatImpl());
    }

    //고양이를 찾는 Ray를 눈에서 발사!
    IEnumerator SearchCatImpl()
    {

        while (true)
        {
            yield return null;
            Vector3 f = transform.TransformDirection(Vector3.forward * 1000);
            Debug.DrawRay(transform.position, f, Color.green);
            if (Physics.Raycast(transform.position, f, out hit))
            {
                if (!isFound && hit.collider.tag=="Cat")
                {
                    isFound = true;
                    Debug.Log("고양이다");
                    DelegateManager.Instance.FoundCatOperation();
                }
            }
        }
    }
}
