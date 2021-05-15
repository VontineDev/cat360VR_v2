﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    [SerializeField]
    AudioSource miaow;

    bool isMiaow;

    private void Start()
    {
        isMiaow = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            miaowSound();
        }
        
    }

   public void miaowSound()
    {
        if(isMiaow == false)
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
