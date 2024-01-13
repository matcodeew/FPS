using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    string SceneToLoad = "Game";
    [SerializeField] GameObject expliquation;

    private void Start()
    {
        expliquation.SetActive(false);
    }
    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void StartExplication()
    {
        expliquation.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
