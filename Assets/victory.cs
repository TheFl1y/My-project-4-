using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public string Win1;

    public GameObject objectWithScript;

    private bool hasLoaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("主角") && !hasLoaded)
        {
            StartCoroutine(LoadAndSwitchScene());
        }
    }

    private IEnumerator LoadAndSwitchScene()
    {
        // Load the scene in the background
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Win1", LoadSceneMode.Single);
        //SceneManager.UnloadSceneAsync("期末_建模");
        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        hasLoaded = true;
    }
}
