using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class onCrimeNPC1 : MonoBehaviour
{
    // Ʃ�丮�󿡼��� NPC���� �浹�� ����� ���� �ƴ� Ʃ�丮���� �����ڸ��� �ٷ� �� �տ� ��Ÿ������ �� ����
    public string playerTag = "Player";
    private bool npc = false; //npc�� �浹�ߴ���
    public TextMeshProUGUI npc1; //npc1�� ���� �ؽ�Ʈ
    private static int ScriptNum = 0; //��ȭ ���� ��ȣ

    public Transform TextPos; //�ؽ�Ʈ ��ġ
    public Transform Canvas; //�ؽ�Ʈ ĵ����

    /*
public Vector3 firstPos; //ĵ���� ó�� ��ġ
public Quaternion firstRot; //ĵ���� ó�� ����
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
        if (other.gameObject.tag == playerTag)
        {
            npc = false;
            Debug.Log("NPC ����");
            StopCoroutine(NpcScript());
            //ScriptNum = 0;
            Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
            ScriptNum--;
            if (ScriptNum == 10)
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

                // 0430
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "��, �̹��� ���� ������ �ڳ��ΰ�?\n�ݰ���. ���� ���尨������ ���� 1�� ������ �� ������.";//��ǰ��� ����
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ð��� ������ ��Ǻ��� �����Ұ�. �����ؼ� �赵�� ��.";//��ȣ�� ���� ����
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "��� �������� ���� ���ϸ�, ���� 4�� 15�а濡 �� ������ �������ִٴ� �Ű� ���Դٰ� ��.\n�Ű��ڴ� ������ �������� ������ �ǰ�.";
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� ���� ���� �����־��� �����ڰ� �Ž� �߾ӿ� �ǽ��� ���� ä �������־��ٰ� ��.";//���� ���Ĺ�� ����
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�⵿ ���� �߰��� �����ڴ� �ǽ��� ���� ���� �Ӹ��� �б�� ���� ���� ��ó�� �־��ٰ� �ϴ����.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 5)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ �����ڸ� �������� �̼۽�Ų �ľ�. \n�����ڰ� 60��� ���̰� �־ ����� ������ ������ ������.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 6)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ϴ� �츮�� �� ����� ���� ħ�԰� ��Ĺ����� ����, �� ���� ���ɼ��� ����ΰ� ������ �ž�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 7)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "��� ������ ������, ���������� ���尨���� �����Ϸ��� ��ȣ������ �����ؾ���?";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 8)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� ���ʿ� �ִ� ��� ŰƮ���� ��ȣ��, ����ũ, �尩�� ������ �԰� �ٽ� ��.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 9)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�����Ϸ��� ���� ��ȣ���� ������ ��� �ڵ����� ������ �ž�.";//���� NPC���� Ȯ�ι������ ���� 0517 ����

                }
                else if (ScriptNum == 10)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);

                }
                ////////////////////////////////////////////////////////////////////////////////////////
                //2��° ��ȣ�ۿ� ����
                ////////////////////////////////////////////////////////////////////////////////////////
                else if (ScriptNum == 11)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ �� ī�޶�� �������� ���÷� ����ؾ� ��. ���� ������ ���� �� �����?";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 12)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�޼� ��Ʈ�ѷ��� X��ư�� ������ ���� �ո� �޴��� ���� �ž�.\n�ű⿡ �ִ� ī�޶�, ������ �������� ������ ��.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 13)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "������ ���� �������� ���� �ִ� ���� ��� ŰƮ���� ������ �������� ���� ��.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 14)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "��� �ٴϱ⿡ �� �����ϱ� �㸮 �ָӴϿ� �����ϰ� �ٴϸ� ���� �ž�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 15)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ָӴ� ������ ���� �����ϱ� �ʿ��� �͵鸸 ��� �ٴϴٰ� ���� ���� ��ü�Ϸ� ����.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 16)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �ִ��� ã�� �� �ִ� ������ ��� ã��, ��ǰ� ���� �־� ���̴� ���Ź����� ��� �����ؾ� ��.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 17)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���������� �� ���纸�鼭 ����ϰ� ������ ���̸� �װ��� ���������� ������.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 18)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�߿��� ��, �ٷ� ����� ���� ���� �� ���� ����� ���� ����� ���� �Ẹ�� �ž�. �̰� �츰 \"���� �׽�Ʈ\"��� ����.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 19)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ٷ� ����� �õ��ߴٰ� �߿��� �ܼ��� ���� 'ġ������ �Ǽ�'�� �� �� ������, �̸� �����ϰ� �׽�Ʈ�ϴ� �ž�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 20)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "���� �׽�Ʈ ��ġ�� ���忡 ���� �����ϴ� ���� �˰� �� �ž�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 21)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� ��°�� �߿��� ��, ��� �� �� �ִ� ���Ź����� ���忡�� �������� �ʾ�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 22)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�����ϱ� ����� �͵��� ���忡�� ������ ä���ϰ�, ������ �� �ִ� ���Ź����� ����û �� �м��Ƿ� �������� �����ؾ� ��.";//���� NPC���� Ȯ�ι������ ����

                }

                else if (ScriptNum == 23) //0517 �߰�
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�׷��ϱ� ������ �������� ������ ���̴� ���Ź��� Ȯ�� �� ���� ��� �ٷ� ������.\nGrab���� ��� Y��ư�� Ŭ���ϸ� ������ �ž�.";//���� NPC���� Ȯ�ι������ ����

                }

                else if (ScriptNum == 24)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�� �����ߴٰ� �����ϸ� ���忡 �ִ� �������� ���� Ȯ�ι޾�.";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 25)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�ٽ� �ѹ� ��������, ���� ���� �߿���! \n���� �߰��ϸ� ����! ������ ����Ǹ� ����! ä���� �Ŀ��� ����!";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 26)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "�Ǽ� �ϳ��ϳ��� ������ ��ĥ ���� �ִٴ� �� ����ϵ���!";//���� NPC���� Ȯ�ι������ ����

                }
                else if (ScriptNum == 27)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = 10; // �ٽ� ��ȭ�� �ɸ� 10������ �����ϰ� �ݺ�
                }
                ScriptNum++;

                /*
                if (ScriptNum == 0)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Crime summary";//��ǰ��� ����
                }
                else if (ScriptNum == 1)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Wearing protective clothes";//��ȣ�� ���� ����
                }
                else if (ScriptNum == 2)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "UI and inventory" + ScriptNum;//UI�� �κ��丮 ����
                }
                else if (ScriptNum == 3)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Crime Scene Forensic" + ScriptNum;//���� ���Ĺ�� ����
                }
                else if (ScriptNum == 4)
                {
                    Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
                    npc1.text = "Confirmation By NPC2" + ScriptNum;//���� NPC���� Ȯ�ι������ ����

                }


                else if (ScriptNum == 5)
                {
                    Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                    ScriptNum = 2; // �ٽ� ��ȭ�� �ɸ� 3������ �����ϰ� �ݺ�
                }
                ScriptNum++;
                */
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
