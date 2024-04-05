using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    private int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}


// 점수를 추가하는 예시
// ScoreManager.Instance.AddScore(10);

// 점수를 가져오는 예시
// int currentScore = ScoreManager.Instance.GetScore();

// 점수를 리셋하는 예시
// ScoreManager.Instance.ResetScore();
