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


// ������ �߰��ϴ� ����
// ScoreManager.Instance.AddScore(10);

// ������ �������� ����
// int currentScore = ScoreManager.Instance.GetScore();

// ������ �����ϴ� ����
// ScoreManager.Instance.ResetScore();
