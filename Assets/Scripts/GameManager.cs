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
    public int lives;
    public GameObject gameOverDisplay;
    public TextMeshProUGUI lifeDisplay;

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
        lifeDisplay.text = $"lives {lives}";
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
}
