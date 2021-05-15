using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image image;

    void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    void Update()
    {
        
    }

    public IEnumerator FadeCoroutine()
    {
        float fadeCount = 1.0f;

        while(fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
