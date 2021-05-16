using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FadeManager : MonoBehaviour
{
    public Image image;

    public GameObject panel;

    private void Start()
    {
        DelegateManager.Instance.FadeOperate += Instance_FadeOperate;
    }


    private void Instance_FadeOperate()
    {
        print($"FadeManager Instance_FadeOperate");

        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // 페이드 인 - 투명한 화면이 점점 검어진다
    IEnumerator FadeInCoroutine()
    {
        float fadeCount = 0;

        image.color = new Color(0, 0, 0, 0);

        panel.SetActive(true);

        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        //페이드인이 끝남
        DelegateManager.Instance.WorldChangeOperation();
        panel.SetActive(false);

        FadeOut();
    }

    // 페이드 아웃 - 검은 화면이 점점 투명해진다
    IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 1.0f;

        image.color = new Color(0, 0, 0, 1);

        panel.SetActive(true);

        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        panel.SetActive(false);
    }
}
