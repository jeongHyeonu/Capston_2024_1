using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public static GameObject npc1Object;


    //충돌한 객체의 Trigger안에 있을때 
    //----------------------------------
    // 충돌처리 방법 중 OnTrigger는 물리 연산X, 관통OK & OnCollision는 물리 연산O, 관통 X
    // Player가 NPC의 범위 안으로 들어가는 걸 파악하기 위해 Trigger 사용
    void OnTriggerStay(Collider other)  //NPC와 충돌
    {
        // Player가 NPC1과 충돌했을 경우
        if (other.tag == "NPC1")
        {
            npc1Object = other.gameObject;  //NPC1를 scanObject로 저장
        }
    }

}
