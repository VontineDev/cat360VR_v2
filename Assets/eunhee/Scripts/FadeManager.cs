using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image image;

    public GameObject panel;

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }


    IEnumerator FadeInCoroutine()
    {
        float fadeCount = 0;

        image.color = new Color(0, 0, 0, 1);

        panel.SetActive(true);

        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        panel.SetActive(false);
    }

    IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 1.0f;

        image.color = new Color(0, 0, 0, 0);

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
