using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject Mainmenu;

    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Mainmenu.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMainMenu()
    {
        Application.Quit();
        Mainmenu.SetActive(true);
    }


}
