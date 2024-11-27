using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    public float horizontalLimit;
    public float verticalLimit;
    public float offset;
    public float safetyRadius;

    public int maxLives;
    private int lives;
    public GameObject gameOverDisplay;
    public TextMeshProUGUI lifeDisplay;
    public Vector3 spawnPoint = Vector3.zero;
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void UpdateLives()
    {
        lifeDisplay.text = $"Lives: {lives}";
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void LoseLives()
    {
        lives--;
        UpdateLives();
    }

    IEnumerator RespawnPlayer()
    {

        yield return new WaitForSeconds(1);

        GameObject[] pointers = GameObject.FindGameObjectsWithTag("Enemy");

        bool canSpawn = false;

        while(!canSpawn)
        {
            foreach(GameObject pointer in pointers)
            {
                if((pointer.transform.position - spawnPoint).magnitude < safetyRadius)
                {
                    canSpawn = false;
                }
            }
        }

        Instantiate(playerPrefab, spawnPoint, playerPrefab.transform.rotation);
    }

    public void PlayerDie()
    {
        LoseLives();
        StartCoroutine(RespawnPlayer());
    }
}
