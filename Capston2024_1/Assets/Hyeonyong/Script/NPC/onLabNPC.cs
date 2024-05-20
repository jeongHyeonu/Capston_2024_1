using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onLabNPC : MonoBehaviour
{
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
            if (ScriptNum == 6)
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
                    npc1.text = "아직 할 일이 남았어!";//다 찾았어? 더 안찾아봐도 됨?


                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_1);
                }
                //else if (ScriptNum == 1 && onsubmit == false)
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "아까 현장에서 가져온 증거물 있지?\n그 증거물도 지문 검출을 해봐야 해!";//다 찾았어? 더 안찾아봐도 됨?
                                                                            //Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_2);
                }


                //else if (ScriptNum == 2 && onsubmit == false)
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "여긴 '증거 분석실'이라는 곳인데\n현장에서 수집해 온 증거물들을 분석하고 감식하는 곳이야.\n현장에서 못하는 다양한 기법을 사용할 수 있지.";//다 찾았어? 더 안찾아봐도 됨?
                    
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_3);
                }

                //else if (ScriptNum == 3 && onsubmit == false)
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "오른쪽 실험대에 자네가 수집해 온 증거물들 배치해뒀으니까,\n가져가서 감식 진행해.";//다 찾았어? 더 안찾아봐도 됨?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_4);
                }

                else if (ScriptNum == 4)//0517 추가
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "현장에서 처럼 마스크랑 장갑 착용하는 거 잊지말고!\n손을 가져다 대면 착용될 거야.";//다 찾았어? 더 안찾아봐도 됨?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_5);
                }

                //else if (ScriptNum == 4 && onsubmit == false)
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "종이류는 최대한 핀셋으로 잡아야 하는 거 잊지 마!";//다 찾았어? 더 안찾아봐도 됨?
                                                               //버튼이 생성되는 코드, 평가표가 나타나는 코드

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_6);
                }


                else if (ScriptNum == 6)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }

                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "다 끝났으면 증거물을 다시 잘 밀봉해서\n오른쪽 보관 박스에 확인하고 넣고, 지문 전사지도 넣어.";//다 찾았어? 더 안찾아봐도 됨?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_7);
                }

                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "넣고 나면 위에 뜬 버튼을 클릭하면 될거야!\n고생 많았어!";//다 찾았어? 더 안찾아봐도 됨?
                    //결과 확인버튼 활성화
                    CheckButton.SetActive(true);

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_8);
                }

                else if (ScriptNum == 9)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                }
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

        SceneManager.LoadScene("Lab_Hyeonyong");
    }
}
