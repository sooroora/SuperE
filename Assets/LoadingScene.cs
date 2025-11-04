using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // Scene 이름 불러와야함
        
        AsyncOperation async = SceneManager.LoadSceneAsync("GameScene_YohanMap");
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            if (async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
