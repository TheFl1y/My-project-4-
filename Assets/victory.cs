using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public string Win;

    private bool hasLoaded = false; // To track if the scene has been loaded

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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Win);

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Set the flag to indicate that the scene has been loaded
        hasLoaded = true;

        // Optionally, you can add additional logic here after the scene has been loaded
    }
}
