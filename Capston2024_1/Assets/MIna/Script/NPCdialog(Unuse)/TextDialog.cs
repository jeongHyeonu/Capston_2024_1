// �з� : UI > Inventory
// ��ġ : Assets > MyScript for UI > NPCDialog
// ���� : dialog �ȿ� �� ����&��ȣ�ۿ�
// ��� : dialog�� �� canvas(NPC�� �ڽİ�ü)�� panel���� �����.


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    // �������� �� �� �ְ� ���ش�.
    [TextArea]
    public string dialogue;
}


public class TextDialog : MonoBehaviour
{
    static public int npc_talk_int = 0;
    Boolean justOne = false;
    public Text txt_Dialogue;






















    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
