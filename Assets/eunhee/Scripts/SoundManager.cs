using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;



    [SerializeField]
    AudioSource miaow;      //AudioSource of cat

    bool isMiaow;          //is cat crying?

    AudioSource bgm;       //AudioSource of bgm


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        isMiaow = false;
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }

    public void miaowSound()
    {
        if (isMiaow == false)
        {
            miaow.Play();

            isMiaow = true;
        }
        else
        {
            miaow.Pause();

            isMiaow = false;
        }
    }
}
