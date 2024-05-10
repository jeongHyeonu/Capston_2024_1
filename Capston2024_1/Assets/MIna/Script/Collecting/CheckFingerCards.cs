using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFingerCards : MonoBehaviour
{
    public TextMeshProUGUI Card1_Score8, Card2_Score8, Card3_Score8, Card4_Score8, Card5_Score8;  // ���� ���� ������ ���� Ȯ�� ���� ǥ��

    // ���� Ȯ�� ����
    private int Card1_eight_score = 0;    
    private int Card2_eight_score = 0;   
    private int Card3_eight_score = 0;   
    private int Card4_eight_score = 0;   
    private int Card5_eight_score = 0;   

    private bool Card1_isChecked = false;   //Card1(�� ������) ���� üũ
    private bool Card2_isChecked = false;   //Card2(��Ź) ���� üũ
    private bool Card3_isChecked = false;   //Card3(����) ���� üũ
    private bool Card4_isChecked = false;   //Card4(����) ���� üũ
    private bool Card5_isChecked = false;   //Card5(��ũ��) ���� üũ

    // �ڽ��� ���� ���� ������ Ȯ��(�浹�� �˻�)
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
