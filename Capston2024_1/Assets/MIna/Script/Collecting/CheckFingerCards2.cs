using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFingerCards2 : MonoBehaviour
{
    public TextMeshProUGUI Card6_Score8, Card7_Score8;  // �м��� ���� ������ ���� Ȯ�� ���� ǥ��
   

    // ���� Ȯ�� ����
    private int Card6_eight_score = 0;
    private int Card7_eight_score = 0;
    

    private bool Card6_isChecked = false;   //Card6(���ߺ�) ���� üũ
    private bool Card7_isChecked = false;   //Card7(����) ���� üũ
   


    // �ڽ��� ���� ���Ź� Ȯ��(�浹�� �˻�)
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
