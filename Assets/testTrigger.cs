using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{
    public AudioSource catAudioSource;

    bool isTouchable; //고양이를 만질수 있는가?
    private void Start()
    {
        print($"Unity testTrigger");
        catAudioSource = this.GetComponentInParent<AudioSource>();
        //StartCoroutine(MakeTouchable());
        isTouchable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"testTrigger: OnTriggerEnter, ColliderName : {other.gameObject.name}, tag: {other.tag}");

        if (other.tag == "Hand")
        {
            if (isTouchable)        //한번만터치하도록 한다... 대화창이 미친듯이뜨는소리가들려..
            {
                print($"In the isTouchable");

                isTouchable = false;
                DelegateManager.Instance.TouchCompleteOperation();
            }
        }
    }
    IEnumerator MakeTouchable()     //나중에 또 터치하고싶자너... 그럼 isTouchable을 true로 하는거지
    {
        var waitForSeconds = new WaitForSeconds(7f);

        while (true)
        {
            isTouchable = true;
            yield return waitForSeconds;
        }
    }
}
