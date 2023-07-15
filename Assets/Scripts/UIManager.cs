using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    int score = 0;
    int targetScore = 20;

    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();

        if (score >= targetScore)
        {
            SceneManager.LoadScene("END");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString() + " | " + targetScore.ToString();
    }
}