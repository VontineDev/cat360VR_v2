using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public GameObject rain;
    #region singleton
    public static RainManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    #endregion
    //이함수를 사용하면 끄고 켜고 가능.
    public void SetRain(bool isTrue)
    {
        if(isTrue)
        {
            rain.SetActive(true);
        return;
        }
            rain.SetActive(false);
        
    }
}
