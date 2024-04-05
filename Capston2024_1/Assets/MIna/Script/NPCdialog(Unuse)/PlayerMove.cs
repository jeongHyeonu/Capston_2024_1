using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    // 오른쪽 컨트롤러 B버튼 눌렀을 때 -> 
    void PressButtonA()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.B))   //B버튼이 눌렸을 때
        {
            // DialogUI ui = GetComponent<DialogUI>();
            //
            // NPC1의 충돌 범위 안 일 때 -> NPC1과 대화
            if (PlayerCollider.npc1Object)
            {
                //ui.OpenDialog(PlayerCollider.npc1Object);
            }

        }
    }

    void Update()
    {
        PressButtonA();     //update에서 버튼 detect해야함.
    }
}
