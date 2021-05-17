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


    // 3D Sound에 담을 Clip 파일
    public AudioClip exexSound;


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

    // Sound Object 생성, 3D AudioSource 생성
    public void Exex() { 
    
        // AudioSource를 담을 Sound 이름을 가진 Object 생성
        GameObject soundObj = new GameObject("Sound");

        // SoundObject 위치값 지정
        soundObj.transform.position = new Vector3(1.400165f, -1.0f, -2.653213f);

        // Sound Object 에 AudioSource Component를 생성 하여 넣어 준다.
        AudioSource source = soundObj.AddComponent<AudioSource>();

        // 100%의 Sound를 들을 수 있는 최소 거리 값.
        source.minDistance = 0.5f;

        // 50%의 Sound만 들을 수 있는 최대 거리 값.
        source.maxDistance = 1.5f;

        // AudioSourceCurveType의 SpatialBlend을 가지고 온다(Pan Level Custon Curve)를 가져옴
        AnimationCurve ac = source.GetCustomCurve(AudioSourceCurveType.SpatialBlend);

        // Curve의 KeyFrame을 담을 객체 생성
        Keyframe[] keys = new Keyframe[1];

        // KeyFrame 값을 1으로 변경.
        for (int i = 0; i < keys.Length; ++i)
        {
            keys[i].value = 1f;
        }

        // Curve에 변경 된 키 값을 담아 준다.
        ac.keys = keys;

        // 3D sound로 변경
        source.SetCustomCurve(AudioSourceCurveType.SpatialBlend, ac);

        // AudioSource에 SoundClip 할당
        source.clip = exexSound;

        // Sound 반복 재생 0
        source.loop = true;

        // Sound 재생
        source.Play();
    }
}
