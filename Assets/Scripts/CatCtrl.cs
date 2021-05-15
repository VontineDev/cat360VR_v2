using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Cat_State
{
    idle,
    run,
    walk,
    tail

}
public class CatCtrl : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SetState(Cat_State.idle);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetState(Cat_State.run);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetState(Cat_State.walk);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetState(Cat_State.tail);
        }
    }
    public void SetState(Cat_State state)
    {
        switch (state)
        {
            case Cat_State.idle:
                SetInit();
                break;
            case Cat_State.run:
                SetInit();
                anim.SetBool("isRun", true);
                break;
            case Cat_State.walk:
                SetInit();
                anim.SetBool("isWalk", true);
                break;
            case Cat_State.tail:
                SetInit();
                anim.SetBool("isTail", true);
                break;
            
        }
    }
    public void SetInit()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isTail", false);
    }
}
