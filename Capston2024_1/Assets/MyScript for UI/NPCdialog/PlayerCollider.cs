using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public static GameObject npc1Object;


    //�浹�� ��ü�� Trigger�ȿ� ������ 
    //----------------------------------
    // �浹ó�� ��� �� OnTrigger�� ���� ����X, ����OK & OnCollision�� ���� ����O, ���� X
    // Player�� NPC�� ���� ������ ���� �� �ľ��ϱ� ���� Trigger ���
    void OnTriggerStay(Collider other)  //NPC�� �浹
    {
        // Player�� NPC1�� �浹���� ���
        if (other.tag == "NPC1")
        {
            npc1Object = other.gameObject;  //NPC1�� scanObject�� ����
        }
    }

}
