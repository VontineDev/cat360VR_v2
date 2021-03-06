using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TextStreamer : MonoBehaviour
{
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string str;
    private string[] strArr;
    [Tooltip("출력할 텍스트오브젝트")]
    public Text text;
    private int idx = 0;
    [Tooltip("문장 출력 속도")]
    [Range(2, 10)]
    public float textSpeed;

    public bool isEnd;//창을 닫을 때 판단변수
    public GameObject talkWindow;//대화창
    private IEnumerator corutine;

    // Start is called before the first frame update
    
    public void TextStreaming()
    {

        corutine = textGo(3f);
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
        print(strArr.Length);

    }

    IEnumerator textGo(float time)
    {
        yield return new WaitForSeconds(time);
        text.text = "";
        text.DOText(strArr[idx], textSpeed, true).SetDelay(0f);

        idx++;

        if (idx == strArr.Length)
        {
            if (isEnd)
            {
                Invoke("CloseWindow", 3);
            }
            corutine = null;
            yield break;
        }
        StartCoroutine(textGo(time));
        yield break;
    }
    public void CloseWindow()
    {
        talkWindow.SetActive(false);
    }
}
