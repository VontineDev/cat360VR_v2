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
    private LayerMask origin;

    private int worldNum;
    void Start()
    {
        origin = Camera.main.cullingMask - LayerMask.GetMask("World0");
        //테스트
        test = 0;
        worldNum = 0;
        DelegateManager.Instance.WorldChangeOperate += Instance_WorldChangeOperate;
    }

    private void Instance_WorldChangeOperate()
    {
        worldNum++;
        print("Instance_WorldChangeOperate");

        if (worldNum < 5)
        {
            print($"Instance_WorldChangeOperate WorldNumber: {worldNum}");
            MovePlace(worldNum);
        }
        else
        {
            print("고양이가 다가오게만들어라");
            DelegateManager.Instance.ComeCatOperation();    //ComCatOperation 대리자 호출
        }
    }

  
    /// <summary>
    /// 해당 장소로 이동
    /// </summary>
    public void MovePlace(int num)
    {
        SetLayer();
        switch (num)
        {
            case 0:
                Camera.main.cullingMask += LayerMask.GetMask("World0");
                //  transform.position = Vector3.zero;
                //  eyePos.rotation = Quaternion.identity;
                break;
            case 1:
                RainManager.Instance.SetRain(true);
                Camera.main.cullingMask += LayerMask.GetMask("World1");
                //  transform.position = new Vector3(10, 0, 0);
                //  eyePos.rotation = Quaternion.identity;
                break;
            case 2:

         
                Camera.main.cullingMask += LayerMask.GetMask("World2");
                //  transform.position = new Vector3(20, 0, 0);
                //  eyePos.rotation = Quaternion.identity;
                break;
            case 3:

                Camera.main.cullingMask += LayerMask.GetMask("World3");
                //   transform.position = new Vector3(30, 0, 0);
                //  eyePos.rotation = Quaternion.identity;
                break;
            case 4:
                RainManager.Instance.SetRain(false);
                Camera.main.cullingMask += LayerMask.GetMask("World4");
                //transform.position = new Vector3(40, 0, 0);
                //eyePos.rotation = Quaternion.identity;
                break;
        }
    }
    public void SetLayer()
    {
        Camera.main.cullingMask = origin;
    }
}
