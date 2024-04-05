// 분류 : UI > Inventory
// 위치 : Assets > MyScript for UI > NPCDialog
// 설명 : dialog 안에 들어갈 내용&상호작용
// 비고 : dialog가 될 canvas(NPC의 자식객체)의 panel한테 줘야함.


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    // 여러줄을 쓸 수 있게 해준다.
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
