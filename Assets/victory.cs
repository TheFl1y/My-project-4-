using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    private bool hasLoaded = false; // To track if the scene has been loaded

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("主角") && !hasLoaded)
        {
            // 確保遊戲過關後進入一個狀態，例如顯示過關畫面
            // 在這個例子中，我們使用 Invoke 來延遲執行 LoadNextScene 方法
            Invoke("LoadNextScene", 2f);
            hasLoaded = true;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }

    // 開始遊戲按鈕的回呼函式
    public void AgainGame()
    {
        SceneManager.LoadScene(0);
    }

    // 退出遊戲按鈕的回呼函式
    public void QuitGame()
    {
        Application.Quit();
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class victory : MonoBehaviour
//{

//    private bool hasLoaded = false; // To track if the scene has been loaded

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("主角") && !hasLoaded)
//        {
//            SceneManager.LoadScene(2);
//        }
//    }

    //// 開始遊戲按鈕的回呼函式
    //public void AgainGame()
    //{
    //    SceneManager.LoadScene(0);
    //}

    //// 退出遊戲按鈕的回呼函式
    //public void QuitGame()
    //{
    //    Application.Quit();
    //}

    //private IEnumerator LoadAndSwitchScene()
    //{
    //    // Load the scene in the background
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Win);

    //    // Wait until the scene is fully loaded
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }

    //    // Set the flag to indicate that the scene has been loaded
    //    hasLoaded = true;

    //    // Optionally, you can add additional logic here after the scene has been loaded
    //}
//}
