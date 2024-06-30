using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Player Player;

    public TextMeshProUGUI EnemyMesh;
    int countEnemy;

    public TextMeshProUGUI RoundMesh;
    int RoundCount;

    public TextMeshProUGUI lifeMesh;


    public GameObject munitionImage;
    public GameObject munitionParent;
    public List<GameObject> allMunitionImages = new List<GameObject>();

    public SpawnEnemy spawnEnemy;
    public PlayerShoot shoot;

    float rotationX = 0f;
    float rotationY = 0f;
    float MouseSensibility = 2f;

    private void Start()
    {
        TextCount();
        UpdateTextPosition();
        CreateMunitionSprite();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    private void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * MouseSensibility;
        rotationX = Mathf.Clamp(rotationX, -90f, 90);

        rotationY = Input.GetAxis("Mouse X") * MouseSensibility;

        player.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, rotationY, 0);
    }

    private void LateUpdate()
    {
        TextCount();
    }

    private void TextCount()
    {
        countEnemy = spawnEnemy.EnemySpawn - spawnEnemy.EnemyDead;
        EnemyMesh.text = "Enemy missing : " + countEnemy.ToString();

        RoundCount = spawnEnemy.TotalRound - spawnEnemy.roundwin;
        RoundMesh.text = " round : " + RoundCount.ToString();

        lifeMesh.text = Player.currentPlayerLife.ToString() + " /100";
    }
    private void UpdateTextPosition()
    {
        Vector3 screenpos = Camera.main.WorldToScreenPoint(transform.position);
        EnemyMesh.rectTransform.position = screenpos + new Vector3(1000, 1050, 0);
        RoundMesh.rectTransform.position = screenpos + new Vector3(100, 1050, 0);
    }

    public void CreateMunitionSprite()
    {
        DestroyAllMunitionImage();
        allMunitionImages.Clear();
        for (int i = 0; i < shoot.ammount; i++)
        {
            if(munitionImage != null)
            {
                GameObject newMunition = Instantiate(munitionImage, munitionParent.transform.position + new Vector3(i * 20, 0, 0), Quaternion.identity);
                newMunition.transform.SetParent(munitionParent.transform);

                if(newMunition != null)
                {allMunitionImages.Add(newMunition);}
            }
        }
    }
    public void DestroyAllMunitionImage()
    {
        foreach(var munition in allMunitionImages)
        {
            if(munition != null)
            {
                Destroy(munition);
            }
        }
    }
}