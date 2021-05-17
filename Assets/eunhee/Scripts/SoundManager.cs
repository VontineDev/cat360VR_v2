using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    AudioSource miaow;      //AudioSource of cat

    bool isMiaow;          //is cat crying?

    bool isHappyCat;

    AudioSource bgm;       //AudioSource of bgm

    public AudioSource audioSource;

    public AudioSource happyNyang;


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

        isHappyCat = false;

        bgm = GetComponent<AudioSource>();
      //  bgm.Play();
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
    public void PlaySound()
    {
        audioSource.Play();
    }

    public void happayNyangSound()
    {
        if(isHappyCat == false)
        {
            happyNyang.Play();

            happyNyang.loop = true;

            isHappyCat = false;
        }
        else
        {
            happyNyang.Pause();

            happyNyang.loop = false;

            isHappyCat = true;
        }
    }
}
