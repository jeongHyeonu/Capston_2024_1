using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager_test : MonoBehaviour
{
    private static ScoreManager_test instance;
    public static ScoreManager_test Instance { get { return instance; } }

    // 카메라 점수
    private int fist_camera=0;
    private int second_camera=0;

    //분말 점수
    private int correct_color=0;
    private int correct_size = 0;

    //분말을 묻히고 테이프를 사용했는가
    private int correct_tape = 0;

    //증거물을 봉투에 담았는가?
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


// 점수를 추가하는 예시
// ScoreManager.Instance.AddScore(10);

// 점수를 가져오는 예시
// int currentScore = ScoreManager.Instance.GetScore();

// 점수를 리셋하는 예시
// ScoreManager.Instance.ResetScore();
