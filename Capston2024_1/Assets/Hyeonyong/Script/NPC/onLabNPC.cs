using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onLabNPC : MonoBehaviour
{
    public string playerTag = "Player";
    private bool npc = false; //npc�� �浹�ߴ���
    public TextMeshProUGUI npc1; //npc1�� ���� �ؽ�Ʈ
    private static int ScriptNum = 0; //��ȭ ���� ��ȣ

    public Transform TextPos; //�ؽ�Ʈ ��ġ
    public Transform Canvas; //�ؽ�Ʈ ĵ����


    public GameObject CheckButton;
    /*
public Vector3 firstPos; //ĵ���� ó�� ��ġ
public Quaternion firstRot; //ĵ���� ó�� ����
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


        ////��� Ȯ�� ��ư ��Ȱ��ȭ
        CheckButton.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        //onsubmit = submitfingerprint.submit;
        // �浹�� ��ü�� NPC �±׸� ������ �ִ��� Ȯ��
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC2 �浹");
            StartCoroutine(NpcScript());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            npc = false;
            Debug.Log("NPC ����");
            StopCoroutine(NpcScript());
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 6)
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
            if (buttonPressed && !buttonPreviouslyPressed)
            {
                Debug.Log("��ư�� ���Ƚ��ϴ�.");

                // ��ư�� ������ ���ȴ��� Ȯ��
                buttonPreviouslyPressed = true;

                // ��ư�� ������ �� �ؾ� �� �۾����� ����
                Debug.Log("���� ��ȣ: " + ScriptNum);
                //if (ScriptNum == 0 && onsubmit == false)
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �� ���� ���Ҿ�!";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?


                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_1);
                }
                //else if (ScriptNum == 1 && onsubmit == false)
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�Ʊ� ���忡�� ������ ���Ź� ����?\n�� ���Ź��� ���� ������ �غ��� ��!";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                                                                            //Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_2);
                }


                //else if (ScriptNum == 2 && onsubmit == false)
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� '���� �м���'�̶�� ���ε�\n���忡�� ������ �� ���Ź����� �м��ϰ� �����ϴ� ���̾�.\n���忡�� ���ϴ� �پ��� ����� ����� �� ����.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                    
                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_3);
                }

                //else if (ScriptNum == 3 && onsubmit == false)
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ ����뿡 �ڳװ� ������ �� ���Ź��� ��ġ�ص����ϱ�,\n�������� ���� ������.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_4);
                }

                else if (ScriptNum == 4)//0517 �߰�
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���忡�� ó�� ����ũ�� �尩 �����ϴ� �� ��������!\n���� ������ ��� ����� �ž�.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_5);
                }

                //else if (ScriptNum == 4 && onsubmit == false)
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���̷��� �ִ��� �ɼ����� ��ƾ� �ϴ� �� ���� ��!";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                                                               //��ư�� �����Ǵ� �ڵ�, ��ǥ�� ��Ÿ���� �ڵ�

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_6);
                }


                else if (ScriptNum == 6)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }

                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� �������� ���Ź��� �ٽ� �� �к��ؼ�\n������ ���� �ڽ��� Ȯ���ϰ� �ְ�, ���� �������� �־�.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_7);
                }

                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ְ� ���� ���� �� ��ư�� Ŭ���ϸ� �ɰž�!\n��� ���Ҿ�!";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                    //��� Ȯ�ι�ư Ȱ��ȭ
                    CheckButton.SetActive(true);

                    SoundManager.Instance.PlayTTS(SoundManager.TTS_list.LAB_DESCRIPTION_8);
                }

                else if (ScriptNum == 9)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
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

        SceneManager.LoadScene("Lab_Hyeonyong");
    }
}
