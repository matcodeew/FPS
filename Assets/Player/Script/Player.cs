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

    private float canfire = -1f;

    public Slider slider;
    public int currentPlayerLife;

    string VictoryScene = "Victory";
    string GameOverScene = "GameOver";


    public bool canDash = true;

    /// </varaible modifiable bonus fin de manche>
    public int maxLife = 100;
    public int orbHeal = 15;
    public float fireRate = 0.2f;
    /// </varaible modifiable bonus fin de manche>

    private void Start()
    {
        currentPlayerLife = maxLife;
    }
    private void Update()
    {
        slider.value = currentPlayerLife;
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
                yield return new WaitForSeconds(0.5f - 0.1f);
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
        if (currentPlayerLife <= 0)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene(GameOverScene);
        }
    }

    public int PlayerLife()
    {
        if (currentPlayerLife >= 0)
        {
            currentPlayerLife -= 5;
            return currentPlayerLife;
        }
        else
        {
            return 0;
        }

    }
}