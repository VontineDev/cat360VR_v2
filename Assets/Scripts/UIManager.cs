using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    [SerializeField]
    GameObject OVRCameraAnchor;
    [SerializeField]
    GameObject catGo;
    [SerializeField]
    TextMesh textMesh;
    [SerializeField]
    TextMesh textMesh1;
    // Start is called before the first frame update

    
    void Start()
    {
        //DelegateManager.Instance.FoundCatOperate += Instance_FoundCatOperate;

        //DelegateManager.Instance.RunCatOperate += Instance_RunCatOperate;
    }

    private void Instance_RunCatOperate()
    {
       // StartCoroutine(ShowText(OVRCameraAnchor, textMesh1));

     TextA.Instance.PlayText(0, "어? 어디가!");

        DelegateManager.Instance.FadeOperation(); //Fade 실행

        
    }

    private void Instance_FoundCatOperate()
    {
        // StartCoroutine(ShowText(catGo, textMesh));
        TextA.Instance.PlayText(0, "고양이를 발견");
    }
    IEnumerator ShowText(GameObject anchor, TextMesh tm)
    {
        tm.transform.position = anchor.transform.position;
        tm.transform.rotation = Quaternion.LookRotation(transform.position - OVRCameraAnchor.transform.position);
        tm.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        tm.gameObject.SetActive(false);
        yield break;
    }

}
