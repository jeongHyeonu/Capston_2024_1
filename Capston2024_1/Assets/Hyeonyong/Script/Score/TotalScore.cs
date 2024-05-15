using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public TextMeshProUGUI score1_1;
    public TextMeshProUGUI score1_2;
    public TextMeshProUGUI score1_3;
    public TextMeshProUGUI score1_4;
    public TextMeshProUGUI score1_5;
    public TextMeshProUGUI score1_6;
    public TextMeshProUGUI score1_7;
    public TextMeshProUGUI score1_8;    //미나가 추가

    public TextMeshProUGUI score2_1;
    public TextMeshProUGUI score2_2;
    public TextMeshProUGUI score2_3;
    public TextMeshProUGUI score2_4;
    public TextMeshProUGUI score2_5;
    public TextMeshProUGUI score2_6;
    public TextMeshProUGUI score2_7;
    public TextMeshProUGUI score2_8;    //미나가 추가

    public TextMeshProUGUI score3_1;
    public TextMeshProUGUI score3_2;
    public TextMeshProUGUI score3_3;
    public TextMeshProUGUI score3_4;
    public TextMeshProUGUI score3_5;
    public TextMeshProUGUI score3_6;
    public TextMeshProUGUI score3_7;
    public TextMeshProUGUI score3_8;    //미나가 추가

    public TextMeshProUGUI score4_1;
    public TextMeshProUGUI score4_2;
    public TextMeshProUGUI score4_3;
    public TextMeshProUGUI score4_4;
    public TextMeshProUGUI score4_5;
    public TextMeshProUGUI score4_6;
    public TextMeshProUGUI score4_7;
    public TextMeshProUGUI score4_8;    //미나가 추가

    public TextMeshProUGUI score5_1;
    public TextMeshProUGUI score5_2;
    public TextMeshProUGUI score5_3;
    public TextMeshProUGUI score5_4;
    public TextMeshProUGUI score5_5;
    public TextMeshProUGUI score5_6;
    public TextMeshProUGUI score5_7;
    public TextMeshProUGUI score5_8;    //미나가 추가

    public TextMeshProUGUI totalScore;

    public int total = 0;


    public bool onLab = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void GetTotalScore()
    {
        total += int.Parse(score1_1.text);
        total += int.Parse(score1_2.text);
        total += int.Parse(score1_3.text);
        total += int.Parse(score1_4.text);
        total += int.Parse(score1_5.text);
        total += int.Parse(score1_6.text);
        total += int.Parse(score1_7.text);
        total += int.Parse(score1_8.text);  //미나가 추가

        total += int.Parse(score2_1.text);
        total += int.Parse(score2_2.text);
        total += int.Parse(score2_3.text);
        total += int.Parse(score2_4.text);
        total += int.Parse(score2_5.text);
        total += int.Parse(score2_6.text);
        total += int.Parse(score2_7.text);
        total += int.Parse(score2_8.text);  //미나가 추가


        if (onLab == false)
        {
            total += int.Parse(score3_1.text);
            total += int.Parse(score3_2.text);
            total += int.Parse(score3_3.text);
            total += int.Parse(score3_4.text);
            total += int.Parse(score3_5.text);
            total += int.Parse(score3_6.text);
            total += int.Parse(score3_7.text);
            total += int.Parse(score3_8.text);  //미나가 추가

            total += int.Parse(score4_1.text);
            total += int.Parse(score4_2.text);
            total += int.Parse(score4_3.text);
            total += int.Parse(score4_4.text);
            total += int.Parse(score4_5.text);
            total += int.Parse(score4_6.text);
            total += int.Parse(score4_7.text);
            total += int.Parse(score4_8.text);  //미나가 추가

            total += int.Parse(score5_1.text);
            total += int.Parse(score5_2.text);
            total += int.Parse(score5_3.text);
            total += int.Parse(score5_4.text);
            total += int.Parse(score5_5.text);
            total += int.Parse(score5_6.text);
            total += int.Parse(score5_7.text);
            total += int.Parse(score5_8.text);  //미나가 추가
        }
        totalScore.text = "" + total;
    }
}
