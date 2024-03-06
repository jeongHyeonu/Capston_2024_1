// �з� : UI > Inventory
// ��ġ : Assets > MyScript for UI > NPCDialog
// ���� : NPC�� �������� Player�� ������ Player�� �ٶ󺸵�����. 
// ��� : NPC(dialog�� �� canvas�� �ڽİ�ü�� ��)���� �����.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LookAtPlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
        }

    }
}
