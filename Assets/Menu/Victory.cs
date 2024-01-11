using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    string SceneToLoad = "MainMenu";
    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
