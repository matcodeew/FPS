using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement move;
    [SerializeField] SpawnEnemy spawnEnemy;
    [SerializeField] PlayerShoot shoot;
    [SerializeField] WeaponsReaload weaponReload;

    private float fireRate = 0.2f;
    private float canfire = -1f;

    public Slider slider;
    float mawLife = 100;
    public float playerLife;

    string VictoryScene = "Victory";
    string GameOverScene = "GameOver";

    public bool canDash = true;

    private void Start()
    {
        playerLife = mawLife;
    }
    private void Update()
    {
        slider.value = playerLife;
        if (Input.GetMouseButtonDown(0) && Time.time > canfire)
        {
            canfire = Time.time + fireRate;
            shoot.Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            weaponReload.Reload();
        }

        StartCoroutine(Dash());
        Victory();
        GameOver();
    }

    private IEnumerator Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canDash == true)
            {
                canDash = false;
                move.speed = 200;
                yield return new WaitForSeconds(0.1f);
                move.speed = 20;
                yield return new WaitForSeconds(0.4f);
                canDash = true;
            }

            yield return null;
        }
    }

    private void Victory()
    {
        if (spawnEnemy.roundwin == spawnEnemy.TotalRound)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene(VictoryScene);
        }
    }
    private void GameOver()
    {
        if (playerLife <= 0)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene(GameOverScene);
        }
    }

    public float PlayerLife()
    {
        if (playerLife >= 0)
        {
            playerLife -= Time.time * 0.08f;
            return playerLife;
        }
        else
        {
            return 0f;
        }

    }
}