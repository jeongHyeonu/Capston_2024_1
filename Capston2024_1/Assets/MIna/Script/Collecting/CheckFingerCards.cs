using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFingerCards : MonoBehaviour
{
    public TextMeshProUGUI Card1_Score8, Card2_Score8, Card3_Score8, Card4_Score8, Card5_Score8;  // 현장 지문 전사판 수집 확인 점수 표기

    // 수집 확인 점수
    private int Card1_eight_score = 0;    
    private int Card2_eight_score = 0;   
    private int Card3_eight_score = 0;   
    private int Card4_eight_score = 0;   
    private int Card5_eight_score = 0;   

    private bool Card1_isChecked = false;   //Card1(문 손잡이) 수거 체크
    private bool Card2_isChecked = false;   //Card2(식탁) 수거 체크
    private bool Card3_isChecked = false;   //Card3(의자) 수거 체크
    private bool Card4_isChecked = false;   //Card4(서랍) 수거 체크
    private bool Card5_isChecked = false;   //Card5(싱크대) 수거 체크

    // 박스에 들어온 지문 전사판 확인(충돌로 검사)
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "Door1")
        {
            Card1_isChecked = true;
            Card1_eight_score = 5;
            Card1_Score8.text = Card1_eight_score.ToString();
        }
        if (obj.name == "Chair1")
        {
            Card2_isChecked = true;
            Card2_eight_score = 5;
            Card2_Score8.text = Card2_eight_score.ToString();
        }
        if (obj.name == "Desk1")
        {
            Card3_isChecked = true;
            Card3_eight_score = 5;
            Card3_Score8.text = Card3_eight_score.ToString();
        }
        if (obj.name == "Drawer1")
        {
            Card4_isChecked = true;
            Card4_eight_score = 5;
            Card4_Score8.text = Card4_eight_score.ToString();
        }
        if (obj.name == "WaterTap1")
        {
            Card5_isChecked = true;
            Card5_eight_score = 5;
            Card5_Score8.text = Card5_eight_score.ToString();
        }
    }
}
