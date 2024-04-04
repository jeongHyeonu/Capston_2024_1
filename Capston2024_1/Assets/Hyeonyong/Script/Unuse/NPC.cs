using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Check : MonoBehaviour
{
    public string playerTag = "NPC";
    private bool npc = false;
    public TextMeshProUGUI npc1;
    private int ScriptNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        // 충돌한 객체가 LIGHT 태그를 가지고 있는지 확인
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC 충돌");
            StartCoroutine(NpcScript());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            npc = false;
            Debug.Log("NPC 해제");
            StopCoroutine(NpcScript());
            npc1.text = "";
            ScriptNum = 0;
        }
    }
    // Update is called once per frame
    IEnumerator NpcScript()
    {
        //Debug.Log("코루틴 적용");
        if (Input.GetKeyDown(KeyCode.R)) // R버튼 누르면 대사 시작
        {
            Debug.Log("NPC와 대화");
            if (ScriptNum == 0)
            {
                npc1.text = "A";
            }
            if (ScriptNum == 1)
            {
                npc1.text = "B";
            }
            if (ScriptNum == 2)
            {
                npc1.text = "C";
            }
            if (ScriptNum == 3)
            {
                npc1.text = "D";
            }
            if (ScriptNum == 4)
            {
                npc1.text = "";
            }
            ScriptNum++;
            if (ScriptNum == 5)
            { ScriptNum = 0; }

        }

        yield return new WaitForSeconds(0f);
        if (npc)
        {
            StartCoroutine(NpcScript());
        }
    }
}
