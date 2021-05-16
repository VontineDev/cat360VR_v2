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
    TextStreamer textStreamer;  //텍스트 스트리머

    bool isStarted; //게임이 시작되었는가

    // Start is called before the first frame update
    void Start()
    {
        isStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        print($"GameManager Update");

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            print($"GameManager Update GetDown PrimaryIndexTrigger");

            DelegateManager.Instance.FadeOperation();
        }
    }

    void ShowBtnStart()
    {
        btnStart.gameObject.SetActive(true);
        print($"ShowBtnStart");
    }
}
