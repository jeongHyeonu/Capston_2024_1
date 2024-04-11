using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager_test : MonoBehaviour
{
    private static ScoreManager_test instance;
    public static ScoreManager_test Instance { get { return instance; } }

    // ī�޶� ����
    private int fist_camera=0;
    private int second_camera=0;

    //�и� ����
    private int correct_color=0;
    private int correct_size = 0;

    //�и��� ������ �������� ����ߴ°�
    private int correct_tape = 0;

    //���Ź��� ������ ��Ҵ°�?
    private int final_sequence = 0;

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
