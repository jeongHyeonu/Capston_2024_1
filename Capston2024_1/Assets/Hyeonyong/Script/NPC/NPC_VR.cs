using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static OVRPlugin;

public class NPC_VR : MonoBehaviour
{

    // Ʃ�丮�󿡼��� NPC���� �浹�� ����� ���� �ƴ� Ʃ�丮���� �����ڸ��� �ٷ� �� �տ� ��Ÿ������ �� ����

    public string playerTag = "NPC"; 
    private bool npc = false; //npc�� �浹�ߴ���
    public TextMeshProUGUI npc1; //npc1�� ���� �ؽ�Ʈ
    private static int ScriptNum = 0; //��ȭ ���� ��ȣ

    public GameObject Button;

    public Transform TextPos; //�ؽ�Ʈ ��ġ
    public Transform Canvas; //�ؽ�Ʈ ĵ����

    public Vector3 firstPos; //ĵ���� ó�� ��ġ
    public Quaternion firstRot; //ĵ���� ó�� ����

    // Start is called before the first frame update
    void Start()
    {
        firstPos = Canvas.position;
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);
        //firstRot = Canvas.rotation;

    }
    private void OnTriggerEnter(Collider other)
    {

        // �浹�� ��ü�� NPC �±׸� ������ �ִ��� Ȯ��
        if (other.gameObject.tag == playerTag)
        {
            npc = true;
            Debug.Log("NPC �浹");
            StartCoroutine(NpcScript());
            //Canvas.transform.SetParent(TextPos);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            npc = false;
            Debug.Log("NPC ����");
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

    bool buttonPreviouslyPressed = false;//������ ��ư�� ���ȴ��� Ȯ��
    IEnumerator NpcScript()
    {
        while (npc)
        {
            // ���� �����ӿ��� ��ư�� ���ȴ��� Ȯ��
            bool buttonPressed = OVRInput.Get(OVRInput.Button.Four);

            // ��ư�� ���Ȱ�, ������ ��ư�� ������ �ʾ��� ��쿡�� ����
            if (buttonPressed && !buttonPreviouslyPressed)
            {
                Debug.Log("��ư�� ���Ƚ��ϴ�.");

                // ��ư�� ������ ���ȴ��� Ȯ��
                buttonPreviouslyPressed = true;

                // ��ư�� ������ �� �ؾ� �� �۾����� ����
                Debug.Log("���� ��ȣ: " + ScriptNum);
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
            // ��ư�� �������� ���¸� �ٽ� �����մϴ�.
            else if (!buttonPressed)
            {
                buttonPreviouslyPressed = false;
            }

            yield return null;
        }
    }
}
