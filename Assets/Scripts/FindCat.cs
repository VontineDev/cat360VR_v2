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
    IEnumerator SearchCatImpl()
    {

        while (true)
        {
            yield return null;
            Vector3 f = transform.TransformDirection(Vector3.forward * 1000);
            Debug.DrawRay(transform.position, f, Color.green);
            if (Physics.Raycast(transform.position, f, out hit))
            {
                if (!isFound)
                {
                    isFound = true;
                    Debug.Log("고양이다");
                    DelegateManager.Instance.FoundCatOperation();
                }
            }
        }
    }
}
