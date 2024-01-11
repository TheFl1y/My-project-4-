using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startButton; // 宣告開始按鈕
    public Button quitButton;  // 宣告退出按鈕

    void Start()
    {
        // 在 Start 方法中設定按鈕的功能
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // 開始按鈕的功能
    void StartGame()
    {
        Debug.Log("遊戲開始按鈕被點擊！");
        // 在這裡添加啟動遊戲的邏輯，例如載入主遊戲場景
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
