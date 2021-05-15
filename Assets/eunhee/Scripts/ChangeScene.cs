using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject sceneManagerObj;

    public FadeManager FadeManager;

    private void Start()
    {
        FadeManager = sceneManagerObj.GetComponent<FadeManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock)){

            FadeManager.FadeIn();

            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
