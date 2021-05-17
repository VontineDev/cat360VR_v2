using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextButton : MonoBehaviour
{
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
    [Tooltip("버튼")]
    public Button playButton;
    [Tooltip("Enter로 줄간격 나눈 문장이 출력됩니다.10줄까지가능")]
    [TextArea(1, 10)]
    public string strPlay;
    public TextA ta;

    private bool isNo = false;
    private bool isYes = false;
    private bool isPlay = false;
    private int noCount = 0;
    private void Start()
    {
        noCount = 0;
        isNo = false;
        isYes = false;
        isPlay = false;
    }
    public void SetActiveButton(float time)
    {
        Invoke("SetInvokeButtonYesNO", time);
    }
    private void SetInvokeButtonYesNO()
    {
        Yes.gameObject.SetActive(true);
        No.gameObject.SetActive(true);
    }
    public void SetActivePlayButton(float time)
    {
        Invoke("SetInvokeButtonPlay", time);
    }
    private void SetInvokeButtonPlay()
    {
        playButton.gameObject.SetActive(true);
    }
    //public void 
    public void YesButtonGo(float time)
    {
        if (!isYes)
        {
            ta.PlayText(time,2f, strYes);
            isYes = true;
            DelegateManager.Instance.YesOperation();
        }
    }
    public void NoButtonGo(float time)
    {
        if (!isNo)
        {
           
            switch (noCount)
            {
                case 0:
                    ta.PlayText2(time, 2f, strNo);
                    break;
                case 1:
                    ta.PlayText2(time, 2f, "아 하기싫어.");
                    break;
                case 2:
                    ta.PlayText2(time, 2f, "내 목소리만 들어.");
                    break;
                case 3:
                    ta.PlayText(time, 2f, "으아~가고싶다.");
                    isYes = true;
                    isNo = true;
                    DelegateManager.Instance.YesOperation();
                    break;
            }
            noCount++;
            
        }
    }
    public void PlayButtonGo(float time)
    {
        if (!isPlay)
        {
            ta.PlayText(time, 2f, strPlay);
            Invoke("NextText", time);
            isPlay = true;
        }
    }



    public void NextText()
    {
        ta.PlayText(3f, 2f, ta.str, true, false);
    }

}
