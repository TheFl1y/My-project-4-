using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 開始遊戲按鈕的回呼函式
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // 退出遊戲按鈕的回呼函式
    public void QuitGame()
    {
        Application.Quit();
    }
}
