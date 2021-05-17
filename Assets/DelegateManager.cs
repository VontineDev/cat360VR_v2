using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateManager : MonoBehaviour
{
    #region Property

    public static DelegateManager Instance
    {
        get; set;
    }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    #endregion

    #region Event(delegate)
    //public event Action TextStreamOperate;
    //public event Action LoadOperate;
    public event Action YesOperate;     //Yes버튼 눌렀을 때
    public event Action NoOperate;      //No버튼 눌렀을 때 (미사용)
    public event Action SearchCatOperate;   //고양이 찾기 시작
    public event Action FoundCatOperate;    //고양이를 찾음
    public event Action RunCatOperate;      //고양이가 도망감
    public event Action ComeCatOperate;     //고양이가 다가옴
    public event Action FadeOperate;        //페이드 아웃, 인
    public event Action WorldChangeOperate; //월드 바꾸기
    
    //이벤트핸들러인경우

    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;


    #endregion

    #region Methods
    //public void TextStreamOperation()
    //{
    //    TextStreamOperate?.Invoke();

    //    //조건식 ? 트루일경우: 폴스일경우; 삼항연산자
    //}
    //public void LoadOperation()
    //{
    //    LoadOperate?.Invoke();
    //}
    public void YesOperation()
    {
        YesOperate?.Invoke();
    }
    public void NoOperation()
    {
        NoOperate?.Invoke();
    }
    public void SearchCatOperation()
    {
        SearchCatOperate?.Invoke();
    }
    public void FoundCatOperation()
    {
        FoundCatOperate?.Invoke();
    }
    public void RunCatOperation()
    {
        RunCatOperate?.Invoke();
    }
    public void ComeCatOperation()
    {
        ComeCatOperate?.Invoke();
    }
    public void FadeOperation()
    {
        FadeOperate?.Invoke();
    }

    public void WorldChangeOperation()
    {
        WorldChangeOperate?.Invoke();
    }


    public void SaveEventOperation()
    {
        SaveEvent?.Invoke(this, EventArgs.Empty);  //매개변수가 아직은 없다
    }
    public void LoadEventOperation()
    {
        LoadEvent?.Invoke(this, EventArgs.Empty);  //매개변수가 아직은 없다
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
