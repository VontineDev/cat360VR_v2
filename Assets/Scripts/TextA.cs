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
    public float time;
    private void Start()
    {
        idx = 0;
      strArr =  str.Split('\n');
        StartCoroutine(textGo());
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(strArr[i]);
        }
    }
    IEnumerator textGo()
    {
        yield return new WaitForSeconds(time);
        text.text = "";
        text.DOText(strArr[idx], 2f, true).SetDelay(0f);
        idx++;
        if(idx==strArr.Length)
        {
            yield break;
        }
        StartCoroutine(textGo());
        yield break;
    }
}
