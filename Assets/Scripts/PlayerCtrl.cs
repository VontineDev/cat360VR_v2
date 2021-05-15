using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    /// <summary>
    /// 플레이어 로테이션값 조정할 카메라 달린 오브젝트
    /// </summary>
    public Transform eyePos;
    private int test;//테스트용
    void Start()
    {
        //테스트
        test = 0;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            test++;
            MovePlace(test);
        }
    }
    /// <summary>
    /// 해당 장소로 이동
    /// </summary>
    public void MovePlace(int num)
    {
        switch (num)
        {
            case 0:
                transform.position = Vector3.zero;
               eyePos.rotation = Quaternion.identity;
                break;
            case 1:
                transform.position = new Vector3(10,0,0);
                eyePos.rotation = Quaternion.identity;
                break;
            case 2:
                transform.position = new Vector3(20, 0, 0);
                eyePos.rotation = Quaternion.identity;
                break;
            case 3:
                transform.position = new Vector3(30, 0, 0);
                eyePos.rotation = Quaternion.identity;
                break;
            case 4:
                transform.position = new Vector3(40, 0, 0);
                eyePos.rotation = Quaternion.identity;
                break;
        }
    }
}
