using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene 
{
    private AsyncOperation loadingOperation;
    [SerializeField] private TextMeshProUGUI tmpLoading;


    IEnumerator LoadSceneAsync()
    {
        // Load the main scene asynchronously
        loadingOperation = SceneManager.LoadSceneAsync("StartScene");
        //loadingOperation.allowSceneActivation = false;

        // Wait until the scene is loaded
        while (!loadingOperation.isDone)
        {
            // Update your loading progress UI here
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            tmpLoading.text = "LOADING " + (progress * 100f) + "%";
            yield return null;
        }

        // Once loading is complete, activate the loaded scene
        loadingOperation.allowSceneActivation = true;
    }
}
