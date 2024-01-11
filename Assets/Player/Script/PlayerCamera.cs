using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    public TextMeshProUGUI lifeMesh;
    int countEnemy;

    public TextMeshProUGUI RoundMesh;
    int RoundCount;

    public SpawnEnemy spawnEnemy;

    float rotationX = 0f;
    float rotationY = 0f;
    float MouseSensibility = 2f;

    private void Start()
    {
        TextCount();
        UpdateTextPosition();
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
        lifeMesh.text = "Enemy missing : " + countEnemy.ToString();

        RoundCount = spawnEnemy.TotalRound - spawnEnemy.roundwin;
        RoundMesh.text = " round : " + RoundCount.ToString();
    }
    private void UpdateTextPosition()
    {
        Vector3 screenpos = Camera.main.WorldToScreenPoint(transform.position);
        lifeMesh.rectTransform.position = screenpos + new Vector3(1000, 1050, 0);
        RoundMesh.rectTransform.position = screenpos + new Vector3(100, 1050, 0);
    }
}