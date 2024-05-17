using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class onCrimeNPC1 : MonoBehaviour
{
    // 튜토리얼에서는 NPC와의 충돌로 생기는 것이 아닌 튜토리얼이 끝나자마자 바로 눈 앞에 나타나도록 할 예정
    public string playerTag = "Player";
    private bool npc = false; //npc와 충돌했는지
    public TextMeshProUGUI npc1; //npc1에 대한 텍스트
    private static int ScriptNum = 0; //대화 순서 번호

    public Transform TextPos; //텍스트 위치
    public Transform Canvas; //텍스트 캔버스

    /*
public Vector3 firstPos; //캔버스 처음 위치
public Quaternion firstRot; //캔버스 처음 각도
    */
    // Start is called before the first frame update

    public bool replay = false;
    void Start()
    {
        // firstPos = Canvas.position;
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);
        //firstRot = Canvas.rotation;

    }
    private void OnTriggerEnter(Collider other)
    {

        // 충돌한 객체가 NPC 태그를 가지고 있는지 확인
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC1 충돌");
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
            //ScriptNum = 0;
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 10)
                ScriptNum++;
        }
    }
    // Update is called once per frame

    bool buttonPreviouslyPressed = false;//이전에 버튼이 눌렸는지 확인
    IEnumerator NpcScript()
    {
        while (npc)
        {
            // 현재 프레임에서 버튼이 눌렸는지 확인
            bool buttonPressed = OVRInput.Get(OVRInput.Button.Two);

            // 버튼이 눌렸고, 이전에 버튼이 눌리지 않았을 경우에만 실행
            if (buttonPressed && !buttonPreviouslyPressed)
            {
                Debug.Log("버튼이 눌렸습니다.");

                // 버튼이 이전에 눌렸는지 확인
                buttonPreviouslyPressed = true;

                // 버튼이 눌렸을 때 해야 할 작업들을 수행
                Debug.Log("현재 번호: " + ScriptNum);

                // 0430
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "아, 이번에 들어온 신입이 자네인가?\n반가워. 나는 현장감식팀의 수사 1팀 반장인 김 경위야.";//사건개요 설명
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "시간이 없으니 사건부터 설명할게. 집중해서 듣도록 해.";//보호복 착용 지시
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "담당 경찰관의 보고에 의하면, 오후 4시 15분경에 한 남성이 쓰러져있다는 신고가 들어왔다고 해.\n신고자는 남성의 가족으로 추정이 되고.";
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "집에 오니 문이 열려있었고 피해자가 거실 중앙에 의식을 잃은 채 쓰러져있었다고 해.";//현장 감식방법 설명
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "출동 직후 발견한 피해자는 의식이 없고 왼쪽 머리에 둔기로 가격 당한 상처가 있었다고 하더라고.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "지금은 피해자를 병원으로 이송시킨 후야. \n피해자가 60대로 나이가 있어서 충격이 심했을 것으로 예상해.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 6)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "일단 우리는 이 사건을 강도 침입과 면식범과의 다툼, 두 가지 가능성을 열어두고 수사할 거야.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "사건 설명은 끝났고, 본격적으로 현장감식을 진행하려면 보호복부터 착용해야지?";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "내 왼쪽에 있는 장비 키트에서 보호복, 마스크, 장갑을 꺼내서 입고 다시 와.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 9)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "착용하려면 손을 보호복에 가까이 대면 자동으로 입혀질 거야.";//현장 NPC에게 확인받으라고 설명 0517 변경

                }
                else if (ScriptNum == 10)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }
                ////////////////////////////////////////////////////////////////////////////////////////
                //2번째 상호작용 시작
                ////////////////////////////////////////////////////////////////////////////////////////
                else if (ScriptNum == 11)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "수사할 때 카메라와 손전등은 수시로 사용해야 해. 사전 교육을 받을 때 배웠지?";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 12)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "왼손 컨트롤러의 X버튼을 누르면 왼쪽 손목에 메뉴가 나올 거야.\n거기에 있는 카메라, 손전등 아이콘은 누르면 돼.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 13)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "나머지 감식 도구들은 여기 있는 감식 장비 키트에서 꺼내서 가져가서 쓰면 돼.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 14)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "들고 다니기에 꽤 많으니까 허리 주머니에 장착하고 다니면 편할 거야.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 15)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "주머니 개수가 많지 않으니까 필요한 것들만 들고 다니다가 가끔 도구 교체하러 오고.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 16)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "들어가서 최대한 찾을 수 있는 지문은 모두 찾고, 사건과 관련 있어 보이는 증거물들은 모두 수집해야 해.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 17)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "손전등으로 잘 비춰보면서 희미하게 지문이 보이면 그곳을 집중적으로 수사해.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 18)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "중요한 건, 바로 기법을 쓰지 말고 그 주위 비슷한 곳에 기법을 먼저 써보는 거야. 이걸 우린 \"프리 테스트\"라고 하지.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 19)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "바로 기법을 시도했다가 중요한 단서를 망쳐 '치명적인 실수'가 될 수 있으니, 미리 간단하게 테스트하는 거야.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 20)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "프리 테스트 위치는 현장에 들어가서 수사하다 보면 알게 될 거야.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 21)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "두 번째로 중요한 건, 들고 갈 수 있는 증거물들은 현장에서 감식하지 않아.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 22)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "수집하기 어려운 것들은 현장에서 지문을 채취하고, 수집할 수 있는 증거물들은 경찰청 내 분석실로 가져가서 감식해야 해.";//현장 NPC에게 확인받으라고 설명

                }

                else if (ScriptNum == 23) //0517 추가
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "그러니까 지문이 묻어있을 것으로 보이는 증거물은 확인 후 사진 찍고 바로 수집해.\nGrab으로 잡고 Y버튼을 클릭하면 수집될 거야.";//현장 NPC에게 확인받으라고 설명

                }

                else if (ScriptNum == 24)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "다 수사했다고 생각하면 현장에 있는 선배한테 가서 확인받아.";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 25)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "다시 한번 말하지만, 사진 정말 중요해! \n지문 발견하면 사진! 지문이 검출되면 사진! 채취한 후에도 사진!";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 26)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "실수 하나하나가 범인을 놓칠 수도 있다는 거 명심하도록!";//현장 NPC에게 확인받으라고 설명

                }
                else if (ScriptNum == 27)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = 10; // 다시 대화를 걸면 10번부터 시작하고 반복
                }
                ScriptNum++;

                /*
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Crime summary";//사건개요 설명
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Wearing protective clothes";//보호복 착용 지시
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "UI and inventory" + ScriptNum;//UI와 인벤토리 설명
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Crime Scene Forensic" + ScriptNum;//현장 감식방법 설명
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Confirmation By NPC2" + ScriptNum;//현장 NPC에게 확인받으라고 설명

                }


                else if (ScriptNum == 5)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = 2; // 다시 대화를 걸면 3번부터 시작하고 반복
                }
                ScriptNum++;
                */
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
