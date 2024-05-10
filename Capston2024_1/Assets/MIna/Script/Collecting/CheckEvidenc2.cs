using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckEvidenc2 : MonoBehaviour
{
    public TextMeshProUGUI Ev3_Score8, Ev4_Score8;  // 분석실 지문 전사판 수집 확인 점수 표기

    // 수집 확인 점수
    private int Ev3_eight_score = 0;
    private int Ev4_eight_score = 0;

    private bool Ev3_isChecked = false;   //Ev3(영수증) 수거 체크
    private bool Ev4_isChecked = false;   //Ev4(돈봉투) 수거 체크


    // 박스에 들어온 증거물 확인(충돌로 검사)
    private void OnTriggerEnter(Collider obj)
    {
        
        if (obj.tag == "Ev3")
        {
            Ev3_isChecked = true;
            Ev3_eight_score = 5;
            Ev3_Score8.text = Ev3_eight_score.ToString();
        }
        if (obj.tag == "Ev4")
        {
            Ev4_isChecked = true;
            Ev4_eight_score = 5;
            Ev4_Score8.text = Ev4_eight_score.ToString();
        }
    }
}
