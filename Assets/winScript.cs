using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameWinMenu : MonoBehaviour
{
    public Button replayButton; // 宣告重玩按鈕
    public Button quitButton;   // 宣告退出按鈕

    void Start()
    {
        // 在 Start 方法中設定按鈕的功能
        if (replayButton != null)
        {
            replayButton.onClick.AddListener(ReplayGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    // 重玩按鈕的功能
    void ReplayGame()
    {
        Debug.Log("重玩按鈕被點擊！");
        // 在這裡添加重新啟動遊戲的邏輯，例如載入起始場景
        SceneManager.LoadScene("期末_建模");
    }

    // 退出按鈕的功能
    void QuitGame()
    {
        Debug.Log("退出按鈕被點擊！");
        // 在這裡添加退出應用的邏輯
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
