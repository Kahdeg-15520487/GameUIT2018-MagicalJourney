using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderBehaviour : MonoBehaviour
{
    public static string SceneName;

    // Use this for initialization
    void Start()
    {
        if (!string.IsNullOrEmpty(SceneName))
        {
            StartCoroutine(LoadScene());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        while (async.progress <= 0.89f)
        {
            yield return null;
        }
        SceneName = null;
        async.allowSceneActivation = true;
    }
}
