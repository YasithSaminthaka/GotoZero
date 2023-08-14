using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private AsyncOperation loadingOperation;
    [SerializeField] private TextMeshProUGUI tmpLoading;
    private IEnumerator Start()
    {
        // Load the main scene asynchronously
        loadingOperation = SceneManager.LoadSceneAsync("StartScene");
        //loadingOperation.allowSceneActivation = false;

        // Wait until the scene is loaded
        while (!loadingOperation.isDone)
        {
            // Update your loading progress UI here
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100f) + "%");
            tmpLoading.text = "LOADING " + (progress * 100f) + "%";
            yield return null;
        }

        // Once loading is complete, activate the loaded scene
        loadingOperation.allowSceneActivation = true;
    }
}

