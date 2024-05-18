using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FingerPrintPowder;

// ���� �˻� ��� �ο��� ��ũ��Ʈ
public class FingerPrintObject : MonoBehaviour
{
    public enum ObjectType
    {
        iron,
        flour,
        redFlour,
        none,
    }

    public bool isVisible = false;
    public ObjectType obj_type = ObjectType.none; // ������ �������� � ������ üũ

    [SerializeField] powderType answerPowder;
    [SerializeField] TextMeshProUGUI targetScore1;
    [SerializeField] TextMeshProUGUI targetScore2;
    [SerializeField] GameObject rulerAndCard;
    [SerializeField] Material[] mat = new Material[3];

    // ���ֺ� ������ Ʈ���� Enter�� �Ǵ� ��� ������ Ʈ���� Enter�� ����

    //0515 ������ �����׽�Ʈ NPC �ؽ�Ʈ ��ȯ������ �ۼ�
    public bool onFreeTest = false;//true�϶��� ���ǵ���
    public GameObject HandTrigger;
    npcText failed;
    private bool p_first_Failed = false; //�� ���� �ҷ�������
   private bool p_second_Failed = false; //�� ���� �ҷ�������
    public string failed_Text="";
    private int ErrorNum = 1;

    CheckCamera_Freetest checkCamera;
    void Start()
    {
        if (onFreeTest)
        {
            failed = HandTrigger.GetComponent<npcText>();
            checkCamera= GetComponent<CheckCamera_Freetest>();
        }
    }

    //



    private void OnTriggerEnter(Collider other)
    {

        // ���� �� ���̴� ���¶��, ������ ��ü �������� ���� �巯��
        if (isVisible==false && other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            // ����1, ������ ���� �и��� �����°�?
            if (!brushObj.isStrong) targetScore1.text = "15";

            // 0515 ������ �����׽�Ʈ NPC �ؽ�Ʈ ��ȯ �뵵////////////////
            
            if(brushObj.isStrong)
            {
                if (brushObj.p_type != powderType.none && p_first_Failed == false  && onFreeTest==true)
                {
                    //failed_Text += ErrorNum+". "+"�и��� ���� �ʹ� ���ƿ�! �ʹ� ���� ������ ������ ������ �и��� ���� �м��ϱ� ������!\n";
                    p_first_Failed = true;

                    //ErrorNum++;
                }
            }
            //////////////////////////////////////////////////////////
            

            // ����2, �˸��� �� �и��� �����°�?
            if (brushObj.p_type == answerPowder) targetScore2.text = "15";



            // 0515 ������ �����׽�Ʈ NPC �ؽ�Ʈ ��ȯ �뵵//////////////
            
            if (brushObj.p_type != answerPowder)
            {
                if (brushObj.p_type != powderType.none && p_second_Failed == false && onFreeTest == true)
                {
                    /*
                    if (answerPowder == powderType.ironPowder)
                    {
                        failed_Text += "�� ������ ������ �и��� ����� �� ���ƿ�.";

                    }
                    if (answerPowder == powderType.fluorescencePowder)
                    {
                        failed_Text += "�� ������ �ʷϻ� ���� �и��� ����� �� ���ƿ�.\n";
                    }
                    if (answerPowder == powderType.fluorescenceRedPowder)
                    {
                        failed_Text += "�� ������ ������ ���� �и��� ����� �� ���ƿ�.\n";
                    }*/
                    //failed_Text += ErrorNum + ". " + "��ü�� ����� ���� ���� ������ �� �Ⱥ����� ������ �� ��ܿ�! �ݴ�Ǵ� ���� ����ؿ�!\n";
                    p_second_Failed = true;
                   // ErrorNum++;
                }
            }
            
            if(onFreeTest==true) 
            {
                if (checkCamera.first_check == false || p_first_Failed == true || p_second_Failed == true)
                {
                    if (checkCamera.first_check==false)
                    {
                        //failed_Text = ErrorNum + ". " + "���Ź� �������� ������! ����ϴ� �� �߿��ϴ� �� ���� ������!\n" + failed_Text;
                        failed_Text = ErrorNum + ". " + "���Ź� �������� ������! ����ϴ� �� �߿��ϴ� �� ���� ������!";
                        ErrorNum++;
                        if (p_first_Failed == true || p_second_Failed == true)
                        {
                            failed_Text += "\n\n";
                        }
                    }

                    if (p_first_Failed == true)
                    {


                        failed_Text += ErrorNum + ". " + "�и��� ���� �ʹ� ���ƿ�! �ʹ� ���� ������ ������ ������ �и��� ���� �м��ϱ� ������!";
                        ErrorNum++;
                        if (p_second_Failed == true)
                        {
                            failed_Text += "\n\n";
                        }
                    }

                    if (p_second_Failed == true)
                    {
                        failed_Text += ErrorNum + ". " + "��ü�� ����� ���� ���� ������ �� �Ⱥ����� ������ �� ��ܿ�! �ݴ�Ǵ� ���� ����ؿ�!";
                        ErrorNum++;
                    }
                    failed.FailedPowder(failed_Text);
                }
            }
            
            ///////////////////////////////////////////////////////////

            if (brushObj.p_type == powderType.ironPowder) // ö���� ��������, ���͸��� ����
            {
                obj_type = ObjectType.iron;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
            }

            if (brushObj.p_type == powderType.fluorescencePowder) // �������� ��������, ���͸��� ����
            {
                obj_type = ObjectType.flour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder) // �������� ��������, ���͸��� ����
            {
                obj_type = ObjectType.redFlour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[2];
            }

            // ���� ���̰Բ�
            this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
            isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
            rulerAndCard?.SetActive(true); // ���� ���̸� ��/ī�� ����

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_3); // ����
        }
    }
}
