using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    string SceneToLoad = "Game";

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
