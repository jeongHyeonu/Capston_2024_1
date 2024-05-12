using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCrimeNPC2 : MonoBehaviour
{
    // Ʃ�丮�󿡼��� NPC���� �浹�� ����� ���� �ƴ� Ʃ�丮���� �����ڸ��� �ٷ� �� �տ� ��Ÿ������ �� ����
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
            if (ScriptNum == 1)
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
                    npc1.text = "���� ������ �� �����̳���? �� �� ã�ƺ��ŵ� �ǰھ��?";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
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
                    npc1.text = "���� �����ϼ̳���? �˰ڽ��ϴ�.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                }

                //else if (ScriptNum == 3 && onsubmit == false)
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ ���Ź����� �� ������ �ڽ��� ������ �־��ֽ� ��, ä���� ���� �����ǵ��� ���� �ּ���.\n������ ������ ����Ϸ� ��ư�� �����ּ���.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                }

                //else if (ScriptNum == 4 && onsubmit == false)
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ ������ ���� �帱 �ſ���. ��ǥ Ȯ���� ������ ��ư�� �����ּ���.";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                    //��ư�� �����Ǵ� �ڵ�, ��ǥ�� ��Ÿ���� �ڵ�
                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);


                    //��� Ȯ�ι�ư Ȱ��ȭ
                    CheckButton.SetActive(true);
                }
                /*
                if (ScriptNum == 0 && onsubmit == false)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Did you find everything?";//�� ã�Ҿ�? �� ��ã�ƺ��� ��?
                }
                else if (ScriptNum == 1 && onsubmit == false)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Put the evidence into the box, and give me the fingerprints";//���Ŵ� �ڽ� ������ ������
                }


                else if (ScriptNum == 2 && onsubmit == false)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = -1; // �ٽ� ��ȭ�� �ɸ� 3������ �����ϰ� �ݺ�
                }

                else if (onsubmit == true && onsubmit_clean == false) {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "scorecard";//���ھ�� �����ٰ�
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

        //SceneManager.LoadScene("Lab_Hyeonyong");
        SceneManager.LoadScene("Lab");
    }

}
