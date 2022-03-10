using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
