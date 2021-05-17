using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Cat_State
{
    idle,
    run,
    walk,
    tail

}
public class CatCtrl : MonoBehaviour
{
    public Animator anim;

    const float maxAngle = 360;
    [SerializeField]
    SkinnedMeshRenderer skinnedMesh;

    [SerializeField]
    GameObject OVRCameraRig;
    AudioSource audioSource;

    bool isCatCome;     //is cat come or run?
    // Start is called before the first frame update
    void Start()
    {
        //Set AudioSource
        audioSource = GetComponent<AudioSource>();

        //Set Cat Position and Hiding
        SetCat();

        DelegateManager.Instance.YesOperate += Instance_YesOperate;
        DelegateManager.Instance.FoundCatOperate += Instance_FoundCatOperate;
        DelegateManager.Instance.WorldChangeOperate += Instance_WorldChangeOperate;
        DelegateManager.Instance.SearchCatOperate += Instance_SearchCatOperate;
        DelegateManager.Instance.ComeCatOperate += Instance_ComeCatOperate;
    }

    //ComeCatOperate 대리자 호출하면 동작, 고양이가 나에게 다가온다.
    private void Instance_ComeCatOperate()
    {
        isCatCome = true;
    }
    //SearchCatOperate 대리자 호출하면 동작, 고양이가 소리내기
    private void Instance_SearchCatOperate()
    {
        audioSource.Play();
        print("Instance_SearchCatOperate");
    }

    //WorldChangeOperate 대리자 호출하면 동작, 고양이 위치선정, SearchCatOperate 대리자 호출
    private void Instance_WorldChangeOperate()
    {
        SetCat();     //Set Cat Position and Hiding

        DelegateManager.Instance.SearchCatOperation();
    }

    void SetCat()
    {
        this.transform.eulerAngles = new Vector3(0, Random.Range(0, maxAngle), 0);      //0~360도 회전
        this.transform.position = this.transform.forward * 3 + Vector3.down;        //앞으로3만큼간다, OVRCameraRig가(0,-1,0)으로되므로 Vector3.Down해줌
        this.transform.LookAt(OVRCameraRig.transform);                              //카메라쪽을 쳐다보도록한다
        skinnedMesh.enabled = false;                                                //안보이게숨기기

    }
    private void Instance_FoundCatOperate()
    {
        skinnedMesh.enabled = true;         //고양이를 찾았으므로 보이게한다
        if (isCatCome)
        {
            StartCoroutine(ComeCat());
        }
        else
        {
            StartCoroutine(TurnAndRunCat());    //고양이가 몸을돌려 도망간다.
        }
    }

    void IdleCat()
    {
        SetState(Cat_State.idle);
        //대화창 고양이를 쓰다듬어보자 띄우기
        DelegateManager.Instance.PetCatOperation();
    }

    IEnumerator ComeCat()
    {
        SetState(Cat_State.walk);
        float timePassed = 0;
        float speed = 0.5f;
        while (timePassed < 2f)
        {
            yield return null;
            print("ComeCat");
            timePassed += Time.deltaTime;
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        IdleCat();
    }

    //고양이가 run Animation을 취하고 자신의 foward방향으로 4초동안 도망간다
    IEnumerator RunCat()
    {
        SetState(Cat_State.run);
        float timePassed = 0;
        while (timePassed < 4f)
        {
            timePassed += Time.deltaTime;
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        audioSource.Stop();
        DelegateManager.Instance.RunCatOperation();
        yield break;
    }

    //고양이가 180도 회전한다
    IEnumerator TurnAndRunCat()
    {
        SetState(Cat_State.tail);   //고양이가 꼬리를흔든다
        int angle = 180;
        while (angle > -1)
        {
            this.gameObject.transform.Rotate(Vector3.up, 1f);
            angle--;
            yield return null;
        }

        SetInit();  //애니메이션 이닛

        StartCoroutine(RunCat()); //회전이 끝나면 고양이는 도망간다
        yield break;
    }
    private void Instance_YesOperate()
    {
        print($"Instance_YesOperate");

        DelegateManager.Instance.SearchCatOperation();
    }
    public void SetState(Cat_State state)
    {
        switch (state)
        {
            case Cat_State.idle:
                SetInit();
                break;
            case Cat_State.run:
                SetInit();
                anim.SetBool("isRun", true);
                break;
            case Cat_State.walk:
                SetInit();
                anim.SetBool("isWalk", true);
                break;
            case Cat_State.tail:
                SetInit();
                anim.SetBool("isTail", true);
                break;

        }
    }
    public void SetInit()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isTail", false);
    }
}
