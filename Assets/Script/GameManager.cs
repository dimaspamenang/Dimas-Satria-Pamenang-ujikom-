using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int foodHungerValue = 25;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }
}
