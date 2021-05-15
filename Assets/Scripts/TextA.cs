using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using TMPro;
using UnityEngine.UI;
public class TextA : MonoBehaviour
{
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string str;
    private string[] strArr;
    [Tooltip("출력할 텍스트오브젝트")]
    public Text text;
    private int idx=0;
    [Tooltip("줄간격 나눈 문장 출력 시간 간격")]
    [Range(2,10)]
    public float time;
    [Tooltip("버튼")]
    public Button Yes;
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string strYes;
    [Tooltip("버튼")]
    public Button No;
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string strNo;
    public bool isEnd;//창을 닫을 때 판단변수
    private IEnumerator corutine;
   
    private void Start()
    {
        corutine = textGo();
        idx = 0;
        SetTextStr(str);
        StartCoroutine(corutine);
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(strArr[i]);
        }
    }
    public void SetTextStr(string s)
    {
        idx = 0;
        strArr = s.Split('\n');
    }
    IEnumerator textGo()
    {
        yield return new WaitForSeconds(time);
        text.text = "";
        text.DOText(strArr[idx], 2f, true).SetDelay(0f);
        idx++;
      
        if(idx==strArr.Length)
        {
            if(Yes!=null&&No!=null)
            {
            Invoke("SetActiveButton", 2f);
            }
            corutine = null;
            yield break;
        }
        StartCoroutine(textGo());
        yield break;
    }
    public void SetActiveButton()
    {
        Yes.gameObject.SetActive(true);
        No.gameObject.SetActive(true);
    }
    public void YesButton()
    {
        if(corutine==null)
        {
            corutine = textGo();
        SetTextStr(strYes);
        StartCoroutine(corutine);
        }
    }
    public void NoButton()
    {
        if (corutine == null)
        {
            corutine = textGo();
            SetTextStr(strNo);
            StartCoroutine(corutine);
        }
    }
}
