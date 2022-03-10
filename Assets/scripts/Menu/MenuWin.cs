using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    // Start is called before the first frame update
      void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
