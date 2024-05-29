using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onTutorialNPC : MonoBehaviour
{
    // 튜토리얼에서는 NPC와의 충돌로 생기는 것이 아닌 튜토리얼이 끝나자마자 바로 눈 앞에 나타나도록 할 예정
    public string playerTag = "Player";
    private bool npc = false; //npc와 충돌했는지
    public TextMeshProUGUI npc1; //npc1에 대한 텍스트
    private int ScriptNum = 0; //대화 순서 번호

    public Transform TextPos; //텍스트 위치
    public Transform Canvas; //텍스트 캔버스

    public bool quiz_Check = true; 

    public GameObject Quiz1_O;
    public GameObject Quiz1_X;

    public GameObject Quiz2_O;
    public GameObject Quiz2_X;

    public GameObject Quiz3_O;
    public GameObject Quiz3_X;

    public GameObject Quiz4_O;
    public GameObject Quiz4_X;

    public GameObject nextScene;


    public bool quiz_on = false;


    void Start()
    {
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);

        Quiz1_O.SetActive(false);
        Quiz2_O.SetActive(false);
        Quiz3_O.SetActive(false);
        Quiz4_O.SetActive(false);
        Quiz1_X.SetActive(false);
        Quiz2_X.SetActive(false);
        Quiz3_X.SetActive(false);
        Quiz4_X.SetActive(false);
        nextScene.SetActive(false);


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
        if (other.gameObject.tag == playerTag &&quiz_on==false)
        {
            npc = false;
            Debug.Log("NPC 해제");
            StopCoroutine(NpcScript());
            //ScriptNum = 0;
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 9)
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
            if (buttonPressed && !buttonPreviouslyPressed &&quiz_Check==true)
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
                    npc1.text = "안녕하세요. 이곳은 신입 과학수사요원을 교육하기 위한 장소입니다.\n당신은 지문 감식요원으로서 현장에서 잠재지문을 검출하는 업무를\n배정받게 될 거예요.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_1);
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "지문 감식은 과학수사의 가장 기본이자 아주 중요한 과정이에요.";//보호복 착용 지시
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_2);
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "모든 사람은 각자 고유한 지문의 형태를 갖고 있어요.\n그래서 현장에 남겨진 지문은 범인을 정확하게 색출해낼 수 있는\n아주 중요한 단서가 되죠.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_3);
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "특히 우리나라는 \"주민등록증\"을 국민 모두가 만들기 때문에\n지문 감식이 아주 효과적이에요.";//현장 감식방법 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_4);
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "당신이 담당하게 될 \"잠재지문 현출\"이란,\n눈으로 확인이 어려운 지문을 다양한 과학적 기법을 사용해서\n현장에서 바로 검출하는 과정을 말해요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_5);
                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "현장에서는 다양한 색과 종류의 분말을 사용하는 \"분말법\",\n닌히드린 시약을 묻혀 화학반응으로 검출해 내는 \"닌히드린 용액법\"을\n주로 사용해요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_6);
                }
                else if (ScriptNum == 6)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "실제 현장으로 투입되기 전에 먼저\n이곳에서 지문 감식 기법들을 배우고 연습해 보세요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_7);
                }
                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "왼쪽 구역에선 \"분말법\", 오른쪽 구역에선 \"닌히드린 용액법\"을\n연습할 수 있어요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_8);
                }
                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "한 번씩 연습해 보고 난 후 저에게 다시 와서 말을 걸어주세요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_9);
                }
                else if (ScriptNum == 9)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }
                ////////////////////////////////////////////////////////////////////////////////////////
                //2번째 상호작용 시작
                ////////////////////////////////////////////////////////////////////////////////////////
                else if (ScriptNum == 10)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "잘 연습해 보셨나요?\n그럼 현장에 투입되기 전에 마지막으로 확인해 볼게요.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_1);
                }

                else if (ScriptNum == 11)
                {
                    quiz_on = true;
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "먼저 분말법에서 중요한 점으로 퀴즈를 내볼게요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_2);
                }
                else if (ScriptNum == 12)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"1. 분말의 색상은 검체(지문이 묻어있는 증거물)와\n같은 색상이어야 한다?\"";//현장 NPC에게 확인받으라고 설명
                    Quiz1_O.SetActive(true);
                    Quiz1_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3);
                }
                
                else if (ScriptNum == 13)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"2. 붓에 분말을 묻히고 꼭 한 번은 털어내야 한다?\"";//현장 NPC에게 확인받으라고 설명
                    Quiz2_O.SetActive(true);
                    Quiz2_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4);
                }
                else if (ScriptNum == 14)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "다음으로 닌히드린 용액법에서 중요한 점으로 퀴즈를 내볼게요.";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_1);
                }
                else if (ScriptNum == 15)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"1. 닌히드린 용액법은 주로 종이류 증거물에만 사용한다?\"";//현장 NPC에게 확인받으라고 설명
                    Quiz3_O.SetActive(true);
                    Quiz3_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2);
                }
                else if (ScriptNum == 16)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"2. 닌히드린 용액으로 적시고 가만히 내버려두면\n알아서 지문이 나온다?\"";//현장 NPC에게 확인받으라고 설명
                    Quiz4_O.SetActive(true);
                    Quiz4_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3);
                }
                else if (ScriptNum == 17)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "잘 교육이 된 것 같네요!\n지문 감식요원으로서의 첫 활약을 기대합니다!";//현장 NPC에게 확인받으라고 설명
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_4);
                    nextScene.SetActive(true);
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

    public void pressQuiz1_O() {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "틀렸어요!\n효과적인 검출을 위해선 분말의 색상은 검체의 색과 반대되는 게 좋아요!\n\"보색 관계(반대되는 색)\"를 잘 생각해보는 게 도움이 될거예요.";
        Quiz1_O.SetActive(false);
        Quiz1_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3_O);
    }

    public void pressQuiz1_X() {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "맞았어요!";
        Quiz1_O.SetActive(false);
        Quiz1_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3_X);
    }

    public void pressQuiz2_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "맞았어요!";
        Quiz2_O.SetActive(false);
        Quiz2_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4_O);
    }

    public void pressQuiz2_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "틀렸어요!\n너무 많이 묻히게 되면 융선(지문의 무늬를 구성하는 선)에 가루가 껴서\n누구의 지문인지 식별하기 어려워져요! 한 번 정도 털어내는 게 적당합니다.";
        Quiz2_O.SetActive(false);
        Quiz2_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4_X);
    }

    public void pressQuiz3_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "맞았어요!";
        Quiz3_O.SetActive(false);
        Quiz3_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2_O);
    }

    public void pressQuiz3_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "틀렸어요!\n닌히드린 용액법은 주로 흡수가 잘 되는 종이류에 사용해요!\nA4용지, 영수증, 종이봉투 등에 사용되죠. \n그러나 명함처럼 코팅된 종이에는 적합하지 않아요.";
        Quiz3_O.SetActive(false);
        Quiz3_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2_X);
    }


    public void pressQuiz4_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "틀렸어요!\n가만히 내버려두면 시간이 오래 걸리고 지문이 또렷하게 검출되지 않아요!\n그래서 드라이기, 다리미, 오븐 등과 같은 빠르고 확실한 가열 방법을 사용해요.";
        Quiz4_O.SetActive(false);
        Quiz4_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3_O);
    }

    public void pressQuiz4_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "맞았어요!";
        Quiz4_O.SetActive(false);
        Quiz4_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3_X);
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

        //SceneManager.LoadScene("Crime(new)");
        SceneManager.LoadScene("Opening");
    }




}
