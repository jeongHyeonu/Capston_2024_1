// 분류 : UI > Inventory
// 위치 : Assets > MyScript for UI > NPCDialog
// 설명 : NPC가 범위내에 Player가 들어오면 Player를 바라보도록함. 
// 비고 : NPC(dialog가 될 canvas를 자식객체로 둔)한테 줘야함.


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
