using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    // ������ ��Ʈ�ѷ� B��ư ������ �� -> 
    void PressButtonA()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.B))   //B��ư�� ������ ��
        {
            // DialogUI ui = GetComponent<DialogUI>();
            //
            // NPC1�� �浹 ���� �� �� �� -> NPC1�� ��ȭ
            if (PlayerCollider.npc1Object)
            {
                //ui.OpenDialog(PlayerCollider.npc1Object);
            }

        }
    }

    void Update()
    {
        PressButtonA();     //update���� ��ư detect�ؾ���.
    }
}
