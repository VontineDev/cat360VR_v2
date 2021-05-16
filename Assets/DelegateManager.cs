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
    public event Action TextStreamOperate;
    public event Action LoadOperate;
    public event Action YesOperate;
    public event Action NoOperate;
    public event Action SearchCatOperate;
    public event Action FoundCatOperate;
    public event Action RunCatOperate;
    public event Action FadeOperate;

    public event Action WorldChangeOperate;

    //이벤트핸들러인경우

    public event EventHandler SaveEvent;
    public event EventHandler LoadEvent;


    #endregion

    #region Methods
    public void TextStreamOperation()
    {
        TextStreamOperate?.Invoke();

        //조건식 ? 트루일경우: 폴스일경우; 삼항연산자
    }
    public void LoadOperation()
    {
        LoadOperate?.Invoke();
    }
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
