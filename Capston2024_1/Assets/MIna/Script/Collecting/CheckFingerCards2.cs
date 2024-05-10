using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFingerCards2 : MonoBehaviour
{
    public TextMeshProUGUI Card6_Score8, Card7_Score8;  // 분석실 지문 전사판 수집 확인 점수 표기
   

    // 수집 확인 점수
    private int Card6_eight_score = 0;
    private int Card7_eight_score = 0;
    

    private bool Card6_isChecked = false;   //Card6(소중병) 수거 체크
    private bool Card7_isChecked = false;   //Card7(술잔) 수거 체크
   


    // 박스에 들어온 증거물 확인(충돌로 검사)
    private void OnTriggerEnter(Collider obj)
    {
        //if (obj.name == "")
        {
            Card6_isChecked = true;
            Card6_eight_score = 5;
            Card6_Score8.text = Card6_eight_score.ToString();
        }
        //if (obj.name == "")
        {
            Card7_isChecked = true;
            Card7_eight_score = 5;
            Card7_Score8.text = Card7_eight_score.ToString();
        }
    }
}
