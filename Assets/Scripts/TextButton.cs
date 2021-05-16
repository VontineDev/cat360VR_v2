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

    private bool isNo=false;
    private bool isYes = false;
    private bool isPlay = false;
    private void Start()
    {
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
           // DelegateManager.Instance.YesOperation();
           if(isYes)
        {
        ta.PlayText(time,strYes);
            isYes = true;
        }
    }
    public void NoButtonGo(float time)
    {
       if(isNo)
        {
        ta.PlayText(time, strNo);
            isNo = true;
        }
    }
    public void PlayButtonGo(float time)
    {
     if(isPlay)
        {
        ta.PlayText(time, strPlay);
            isPlay = true;
        }
    }
   
}
