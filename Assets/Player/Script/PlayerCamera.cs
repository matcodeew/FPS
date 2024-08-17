using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Player Player;

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
    public void CreateMunitionSprite()
    {
        DestroyAllMunitionImage();
        allMunitionImages.Clear();

        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < shoot.ammount / 2; j++)
            {
                if(munitionImage != null)
                {
                    GameObject newMunition = Instantiate(munitionImage, munitionParent.transform.position + new Vector3(j * 20,i * -50, 0), Quaternion.identity);
                    newMunition.transform.SetParent(munitionParent.transform);

                    if(newMunition != null)
                    {allMunitionImages.Add(newMunition);}
                }
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