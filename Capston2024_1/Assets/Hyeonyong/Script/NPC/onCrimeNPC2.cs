using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCrimeNPC2 : MonoBehaviour
{
    // 튜토리얼에서는 NPC와의 충돌로 생기는 것이 아닌 튜토리얼이 끝나자마자 바로 눈 앞에 나타나도록 할 예정
    public string playerTag = "Player";
    private bool npc = false; //npc와 충돌했는지
    public TextMeshProUGUI npc1; //npc1에 대한 텍스트
    private static int ScriptNum = 0; //대화 순서 번호

    public Transform TextPos; //텍스트 위치
    public Transform Canvas; //텍스트 캔버스


    public GameObject CheckButton;
    /*
public Vector3 firstPos; //캔버스 처음 위치
public Quaternion firstRot; //캔버스 처음 각도
    */
    // Start is called before the first frame update

    public bool replay = false;


    //public submitFingerPrint submitfingerprint;
    //public bool onsubmit=false;
    //public bool onsubmit_clean=false;
    void Start()
    {
        // firstPos = Canvas.position;
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);
        //firstRot = Canvas.rotation;

        //submitfingerprint = gameObject.GetComponent<submitFingerPrint>();


        ////결과 확인 버튼 비활성화
        CheckButton.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        //onsubmit = submitfingerprint.submit;
        // 충돌한 객체가 NPC 태그를 가지고 있는지 확인
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC2 충돌");
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
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 1)
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
                //if (ScriptNum == 0 && onsubmit == false)
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "지문 감식이 다 끝나셨나요? 더 안 찾아보셔도 되겠어요?";//다 찾았어? 더 안찾아봐도 됨?
                }
                //else if (ScriptNum == 1 && onsubmit == false)
                else if (ScriptNum == 1)
                        {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                }


                //else if (ScriptNum == 2 && onsubmit == false)
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "전부 수사하셨나요? 알겠습니다.";//다 찾았어? 더 안찾아봐도 됨?
                }

                //else if (ScriptNum == 3 && onsubmit == false)
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "수집한 증거물들은 제 오른쪽 박스에 조심히 넣어주신 후, 채취한 지문 전사판들은 제게 주세요.\n제출이 끝나면 제출완료 버튼을 눌러주세요.";//다 찾았어? 더 안찾아봐도 됨?
                }

                //else if (ScriptNum == 4 && onsubmit == false)
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "제출이 끝나면 평가해 드릴 거에요. 평가표 확인이 끝나면 버튼을 눌러주세요.";//다 찾았어? 더 안찾아봐도 됨?
                    //버튼이 생성되는 코드, 평가표가 나타나는 코드
                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);


                    //결과 확인버튼 활성화
                    CheckButton.SetActive(true);
                }
                /*
                if (ScriptNum == 0 && onsubmit == false)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Did you find everything?";//다 찾았어? 더 안찾아봐도 됨?
                }
                else if (ScriptNum == 1 && onsubmit == false)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Put the evidence into the box, and give me the fingerprints";//증거는 박스 지문은 나에게
                }


                else if (ScriptNum == 2 && onsubmit == false)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = -1; // 다시 대화를 걸면 3번부터 시작하고 반복
                }

                else if (onsubmit == true && onsubmit_clean == false) {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "scorecard";//스코어보드 보여줄게
                    onsubmit_clean = true;
                }
                else if (onsubmit == true && onsubmit_clean == true)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    onsubmit_clean = false;
                }
                */
                ScriptNum++;


            }
            // 버튼이 떼어지면 상태를 다시 변경합니다.
            else if (!buttonPressed)
            {
                buttonPreviouslyPressed = false;
            }

            yield return null;
        }
    }


    public GameObject CenterEyeObj;  // 오큘러스 CameraRig의 CenterEyeObj 연결
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("씬 이동 시작");
        OFade = CenterEyeObj.transform.GetComponent<OVRScreenFade>();
        StartCoroutine(SceneFadeCoroutine());
    }
    IEnumerator SceneFadeCoroutine()
    {
        OFade.FadeOut();

        yield return new WaitForSeconds(OFade.fadeTime);

        //SceneManager.LoadScene("Lab_Hyeonyong");
        SceneManager.LoadScene("Lab");
    }

}
