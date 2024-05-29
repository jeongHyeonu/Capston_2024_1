using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onTutorialNPC : MonoBehaviour
{
    // Ʃ�丮�󿡼��� NPC���� �浹�� ����� ���� �ƴ� Ʃ�丮���� �����ڸ��� �ٷ� �� �տ� ��Ÿ������ �� ����
    public string playerTag = "Player";
    private bool npc = false; //npc�� �浹�ߴ���
    public TextMeshProUGUI npc1; //npc1�� ���� �ؽ�Ʈ
    private int ScriptNum = 0; //��ȭ ���� ��ȣ

    public Transform TextPos; //�ؽ�Ʈ ��ġ
    public Transform Canvas; //�ؽ�Ʈ ĵ����

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

        // �浹�� ��ü�� NPC �±׸� ������ �ִ��� Ȯ��
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC1 �浹");
            StartCoroutine(NpcScript());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag &&quiz_on==false)
        {
            npc = false;
            Debug.Log("NPC ����");
            StopCoroutine(NpcScript());
            //ScriptNum = 0;
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 9)
                ScriptNum++;
        }
    }
    // Update is called once per frame

    bool buttonPreviouslyPressed = false;//������ ��ư�� ���ȴ��� Ȯ��
    IEnumerator NpcScript()
    {
        while (npc)
        {
            // ���� �����ӿ��� ��ư�� ���ȴ��� Ȯ��
            bool buttonPressed = OVRInput.Get(OVRInput.Button.Two);

            // ��ư�� ���Ȱ�, ������ ��ư�� ������ �ʾ��� ��쿡�� ����
            if (buttonPressed && !buttonPreviouslyPressed &&quiz_Check==true)
            {
                Debug.Log("��ư�� ���Ƚ��ϴ�.");

                // ��ư�� ������ ���ȴ��� Ȯ��
                buttonPreviouslyPressed = true;

                // ��ư�� ������ �� �ؾ� �� �۾����� ����
                Debug.Log("���� ��ȣ: " + ScriptNum);

                // 0430
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ȳ��ϼ���. �̰��� ���� ���м������� �����ϱ� ���� ����Դϴ�.\n����� ���� ���Ŀ�����μ� ���忡�� ���������� �����ϴ� ������\n�����ް� �� �ſ���.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_1);
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� ������ ���м����� ���� �⺻���� ���� �߿��� �����̿���.";//��ȣ�� ���� ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_2);
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "��� ����� ���� ������ ������ ���¸� ���� �־��.\n�׷��� ���忡 ������ ������ ������ ��Ȯ�ϰ� �����س� �� �ִ�\n���� �߿��� �ܼ��� ����.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_3);
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Ư�� �츮����� \"�ֹε����\"�� ���� ��ΰ� ����� ������\n���� ������ ���� ȿ�����̿���.";//���� ���Ĺ�� ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_4);
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "����� ����ϰ� �� \"�������� ����\"�̶�,\n������ Ȯ���� ����� ������ �پ��� ������ ����� ����ؼ�\n���忡�� �ٷ� �����ϴ� ������ ���ؿ�.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_5);
                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���忡���� �پ��� ���� ������ �и��� ����ϴ� \"�и���\",\n�����帰 �þ��� ���� ȭ�й������� ������ ���� \"�����帰 ��׹�\"��\n�ַ� ����ؿ�.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_6);
                }
                else if (ScriptNum == 6)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �������� ���ԵǱ� ���� ����\n�̰����� ���� ���� ������� ���� ������ ������.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_7);
                }
                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �������� \"�и���\", ������ �������� \"�����帰 ��׹�\"��\n������ �� �־��.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_8);
                }
                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� ���� ������ ���� �� �� ������ �ٽ� �ͼ� ���� �ɾ��ּ���.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_9);
                }
                else if (ScriptNum == 9)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }
                ////////////////////////////////////////////////////////////////////////////////////////
                //2��° ��ȣ�ۿ� ����
                ////////////////////////////////////////////////////////////////////////////////////////
                else if (ScriptNum == 10)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� ������ ���̳���?\n�׷� ���忡 ���ԵǱ� ���� ���������� Ȯ���� ���Կ�.";
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_1);
                }

                else if (ScriptNum == 11)
                {
                    quiz_on = true;
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �и������� �߿��� ������ ��� �����Կ�.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_2);
                }
                else if (ScriptNum == 12)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"1. �и��� ������ ��ü(������ �����ִ� ���Ź�)��\n���� �����̾�� �Ѵ�?\"";//���� NPC���� Ȯ�ι������ ����
                    Quiz1_O.SetActive(true);
                    Quiz1_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3);
                }
                
                else if (ScriptNum == 13)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"2. �׿� �и��� ������ �� �� ���� �о�� �Ѵ�?\"";//���� NPC���� Ȯ�ι������ ����
                    Quiz2_O.SetActive(true);
                    Quiz2_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4);
                }
                else if (ScriptNum == 14)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�������� �����帰 ��׹����� �߿��� ������ ��� �����Կ�.";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_1);
                }
                else if (ScriptNum == 15)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"1. �����帰 ��׹��� �ַ� ���̷� ���Ź����� ����Ѵ�?\"";//���� NPC���� Ȯ�ι������ ����
                    Quiz3_O.SetActive(true);
                    Quiz3_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2);
                }
                else if (ScriptNum == 16)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "\"2. �����帰 ������� ���ð� ������ �������θ�\n�˾Ƽ� ������ ���´�?\"";//���� NPC���� Ȯ�ι������ ����
                    Quiz4_O.SetActive(true);
                    Quiz4_X.SetActive(true);
                    quiz_Check = false;
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3);
                }
                else if (ScriptNum == 17)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� ������ �� �� ���׿�!\n���� ���Ŀ�����μ��� ù Ȱ���� ����մϴ�!";//���� NPC���� Ȯ�ι������ ����
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_4);
                    nextScene.SetActive(true);
                }
                ScriptNum++;
            }
            // ��ư�� �������� ���¸� �ٽ� �����մϴ�.
            else if (!buttonPressed)
            {
                buttonPreviouslyPressed = false;
            }

            yield return null;
        }
    }

    public void pressQuiz1_O() {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "Ʋ�Ⱦ��!\nȿ������ ������ ���ؼ� �и��� ������ ��ü�� ���� �ݴ�Ǵ� �� ���ƿ�!\n\"���� ����(�ݴ�Ǵ� ��)\"�� �� �����غ��� �� ������ �ɰſ���.";
        Quiz1_O.SetActive(false);
        Quiz1_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3_O);
    }

    public void pressQuiz1_X() {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "�¾Ҿ��!";
        Quiz1_O.SetActive(false);
        Quiz1_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_3_X);
    }

    public void pressQuiz2_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "�¾Ҿ��!";
        Quiz2_O.SetActive(false);
        Quiz2_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4_O);
    }

    public void pressQuiz2_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "Ʋ�Ⱦ��!\n�ʹ� ���� ������ �Ǹ� ����(������ ���̸� �����ϴ� ��)�� ���簡 ����\n������ �������� �ĺ��ϱ� ���������! �� �� ���� �о�� �� �����մϴ�.";
        Quiz2_O.SetActive(false);
        Quiz2_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_SOLID_QUIZ_4_X);
    }

    public void pressQuiz3_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "�¾Ҿ��!";
        Quiz3_O.SetActive(false);
        Quiz3_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2_O);
    }

    public void pressQuiz3_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "Ʋ�Ⱦ��!\n�����帰 ��׹��� �ַ� ����� �� �Ǵ� ���̷��� ����ؿ�!\nA4����, ������, ���̺��� � ������. \n�׷��� ����ó�� ���õ� ���̿��� �������� �ʾƿ�.";
        Quiz3_O.SetActive(false);
        Quiz3_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2_X);
    }


    public void pressQuiz4_O()
    {

        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "Ʋ�Ⱦ��!\n������ �������θ� �ð��� ���� �ɸ��� ������ �Ƿ��ϰ� ������� �ʾƿ�!\n�׷��� ����̱�, �ٸ���, ���� ��� ���� ������ Ȯ���� ���� ����� ����ؿ�.";
        Quiz4_O.SetActive(false);
        Quiz4_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3_O);
    }

    public void pressQuiz4_X()
    {
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc1.text = "�¾Ҿ��!";
        Quiz4_O.SetActive(false);
        Quiz4_X.SetActive(false);

        quiz_Check = true;
        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_3_X);
    }

    public GameObject CenterEyeObj;  // ��ŧ���� CameraRig�� CenterEyeObj ����
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("�� �̵� ����");
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
