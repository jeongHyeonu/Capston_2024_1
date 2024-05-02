using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static OVRPlugin;

public class NPC_VR : MonoBehaviour
{

    // 튜토리얼에서는 NPC와의 충돌로 생기는 것이 아닌 튜토리얼이 끝나자마자 바로 눈 앞에 나타나도록 할 예정

    public string playerTag = "NPC"; 
    private bool npc = false; //npc와 충돌했는지
    public TextMeshProUGUI npc1; //npc1에 대한 텍스트
    private static int ScriptNum = 0; //대화 순서 번호

    public GameObject Button;

    public Transform TextPos; //텍스트 위치
    public Transform Canvas; //텍스트 캔버스

    public Vector3 firstPos; //캔버스 처음 위치
    public Quaternion firstRot; //캔버스 처음 각도

    // Start is called before the first frame update
    void Start()
    {
        firstPos = Canvas.position;
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);
        //firstRot = Canvas.rotation;

    }
    private void OnTriggerEnter(Collider other)
    {

        // 충돌한 객체가 NPC 태그를 가지고 있는지 확인
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC 충돌");
            StartCoroutine(NpcScript());
            //Canvas.transform.SetParent(TextPos);
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
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            //Canvas.transform.SetParent(null);
            //Canvas.position = firstPos;
            //Canvas.rotation = firstRot;
        }
    }
    // Update is called once per frame

    bool buttonPreviouslyPressed = false;//이전에 버튼이 눌렸는지 확인
    IEnumerator NpcScript()
    {
        while (npc)
        {
            // 현재 프레임에서 버튼이 눌렸는지 확인
            bool buttonPressed = OVRInput.Get(OVRInput.Button.Four);

            // 버튼이 눌렸고, 이전에 버튼이 눌리지 않았을 경우에만 실행
            if (buttonPressed && !buttonPreviouslyPressed)
            {
                Debug.Log("버튼이 눌렸습니다.");

                // 버튼이 이전에 눌렸는지 확인
                buttonPreviouslyPressed = true;

                // 버튼이 눌렸을 때 해야 할 작업들을 수행
                Debug.Log("현재 번호: " + ScriptNum);
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "A" + ScriptNum;
                }
                else if (ScriptNum == 1)
                {
                    npc1.text = "B" + ScriptNum;
                }
                else if (ScriptNum == 2)
                {
                    npc1.text = "C" + ScriptNum;
                }
                else if (ScriptNum == 3)
                {
                    npc1.text = "D" + ScriptNum;
                }
                else if (ScriptNum == 4)
                {
                    npc1.text = "" + ScriptNum;
                    //Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    Button.SetActive(true);
                    
                }

                ScriptNum++;
                if (ScriptNum == 5)
                {
                    ScriptNum = 0;
                }
            }
            // 버튼이 떼어지면 상태를 다시 변경합니다.
            else if (!buttonPressed)
            {
                buttonPreviouslyPressed = false;
            }

            yield return null;
        }
    }
}
