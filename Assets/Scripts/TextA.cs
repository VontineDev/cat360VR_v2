using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using TMPro;
using UnityEngine.UI;
using System;

public class TextA : MonoBehaviour
{
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string str;
    [Tooltip("출력할 텍스트오브젝트")]
    public Text text;
    private int idx = 0;
    [Tooltip("문장 출력 속도")]
    [Range(2, 10)]
    //public float textSpeed;

    public bool isEnd;//창을 닫을 때 판단변수
    public GameObject talkWindow;//대화창
    private IEnumerator corutine;
    private int size;
    public SoundManager sm;
    public TextButton tb;
    #region singleton
    public static TextA Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //  DontDestroyOnLoad(gameObject);
        }
    }

    #endregion
    private void Start()
    {
        DelegateManager.Instance.FoundCatOperate += Instance_FoundCatOperate;
        DelegateManager.Instance.RunCatOperate += Instance_RunCatOperate;
    }

    private void Instance_RunCatOperate()
    {
        var str = "쫓아가자";
        PlayText(2f,2f, str);
        DelegateManager.Instance.FadeOperation();
    }

    private void Instance_FoundCatOperate()
    {
        var str = "찾았다!";
        PlayText(2f,2f, str);
    }

    public void Update()
    {
        //if (OVRInput.GetDown(OVRInput.RawButton.B))
        //{
        //    Debug.Log("zl");
        //    PlayText(3f, "", false, true);
        //}
    }
    /// <summary>
    /// 실행함수
    /// </summary>
    /// <param name="time">시간 </param>
    ///  <param name="s">textArea에쓴 내용 (출력할 텍스트)</param>
    /// <param name="isButtonYesNO">yesno버튼쓸건가요?</param>
    /// <param name="isButtonPlay">플레이버튼쓸껀가요?</param>
    public void PlayText(float time,float textSpeed, string s, bool isButtonYesNO = false, bool isButtonPlay = false)
    {
        string[] strArr = s.Split('\n');
        //일단 대화창 키고
        talkWindow.SetActive(true);
        corutine = textGo(time,textSpeed, strArr);
        StartCoroutine(corutine);
        if (isButtonYesNO)
        {
            tb.SetActiveButton(strArr.Length * time);
        }
        if (isButtonPlay)
        {
            tb.SetActivePlayButton(strArr.Length * time);
        }
        if (!isButtonYesNO && !isButtonPlay)
        {
            //버튼이 없을경우 대화가 끝나고 종료
            Invoke("CloseText", strArr.Length *time);
        }
    }



    public void PlayText2(float time,float textSpeed, string s)
    {
        string[] strArr = s.Split('\n');
        //일단 대화창 키고
        talkWindow.SetActive(true);
        corutine = textGo(time, textSpeed, strArr);
        StartCoroutine(corutine);

    }

    IEnumerator textGo(float time,float textSpeed, string[] strArr)
    {
        idx = 0;

        WaitForSeconds wait = new WaitForSeconds(time);
        while (true)
        {
            text.text = "";
            text.DOText(strArr[idx], textSpeed, true).SetDelay(0f);
            if (string.Join("", strArr) == "")
            {
                yield break;
            }
            int strSpace = 0;
            for (int i = 0; i < strArr[idx].Length; i++)
            {
                if(strArr[idx][i]==' ')
                {
                    strSpace++;
                }
            }
            StartCoroutine(SoundGo(textSpeed / (strArr[idx].Length-strSpace), textSpeed));
            idx++;
            if (idx == strArr.Length)
            {

                yield break;
            }

            yield return wait;
        }
    }

    /// <summary>
    /// 창끄기
    /// </summary>
    public void CloseText()
    {
        talkWindow.SetActive(false);
        tb.playButton.gameObject.SetActive(false);
        tb.Yes.gameObject.SetActive(false);
        tb.No.gameObject.SetActive(false);
    }
    IEnumerator SoundGo(float time, float end)
    {
        float current = 0;
        while (true)
        {
            current += time;
            if (current >= end)
            {
                yield break;
            }
            sm.PlaySound();
            yield return new WaitForSeconds(time);
        }

    }
}
