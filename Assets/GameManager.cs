using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    [SerializeField]
    Button btnStart; //시작버튼
    [SerializeField]
    TextButton tb;  //텍스트 스트리머

    bool isStarted; //게임이 시작되었는가

    // Start is called before the first frame update
    void Start()
    {

        Invoke("StartGame", 5f);
    
    }
    IEnumerator isStart()
    {
        while(true)
        {
            if(isStarted)
            {
                tb.ta.PlayText(3f,2f, tb.ta.str, true, false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print($"GameManager Update");

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    print($"GameManager Update GetDown PrimaryIndexTrigger");

        //    DelegateManager.Instance.FadeOperation();
        //}
    }

    void ShowBtnStart()
    {
        btnStart.gameObject.SetActive(true);
        print($"ShowBtnStart");
    }
    public void StartGame()
    {
        tb.ta.PlayText(3f,4f, "시작하려면 PLAY버튼을 컨트롤러A로 누르세요", false, true);
    }
}
