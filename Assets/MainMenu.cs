using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // �}�l�C�����s���^�I�禡
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // �h�X�C�����s���^�I�禡
    public void QuitGame()
    {
        Application.Quit();
    }
}
