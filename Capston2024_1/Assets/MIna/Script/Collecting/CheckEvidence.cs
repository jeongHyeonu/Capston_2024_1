using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckEvidence : MonoBehaviour
{
    
    public static bool Ev1_isChecked = false;   //Ev1(����) ���� üũ
    public static bool Ev2_isChecked = false;   //Ev2(������) ���� üũ
    public static bool Ev3_isChecked = false;   //Ev3(������) ���� üũ
    public static bool Ev4_isChecked = false;   //Ev4(������) ���� üũ


    // �ڽ��� ���� ���Ź� Ȯ��(�浹�� �˻�)
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Ev1")
        {
            Ev1_isChecked = true;
        }
        if (obj.tag == "Ev2")
        {
            Ev2_isChecked = true;
        }
        if (obj.tag == "Ev3")
        {
            Ev3_isChecked = true;
        }
        if (obj.tag == "Ev4")
        {
            Ev4_isChecked = true;
        }
    }


}
