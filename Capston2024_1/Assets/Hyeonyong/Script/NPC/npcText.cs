using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class npcText : MonoBehaviour
{

    public Transform TextPos; //�ؽ�Ʈ ��ġ
    public Transform Canvas; //�ؽ�Ʈ ĵ����

    public Vector3 firstPos; //ĵ���� ó�� ��ġ
    public Quaternion firstRot; //ĵ���� ó�� ����
    public TextMeshProUGUI npc; //npc1�� ���� �ؽ�Ʈ

    public bool onFailed=false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Clean();
        }*/
    }


    // ���Ź� ������ �Կ����� �ʰ� �и����� �������� ��
    public void FailedFirstCamera() //CheckCamera����
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "first Camera Failed";
        StartCoroutine(Clean());
    }


    // �и��� ���� ���ų� ���� ��
    public void FailedAmountPowder()
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Amount Powder Failed";
        StartCoroutine(Clean());
    }

    // �и��� ������ �������� ���� ��
    public void FailedColorPowder()
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Color Powder Failed";
        StartCoroutine(Clean());
    }


    // �巯�� ������ �Կ����� �ʰ� �������� �ٿ��� ��
    public void FailedSecondCamera() //checkCamera�� FingerPrintTape ����
    {
        Debug.Log("2�� ī�޶� ����");
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Second Camera Failed";
        StartCoroutine(Clean());
    }

    // �������� �Կ����� �ʰ� npc���� �������� ��
    public void FailedThirdCamera() //fingerPrintPaper�� CheckCamera ����
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Third Camera Failed";
        StartCoroutine(Clean());
    }

    
    IEnumerator Clean() {
        
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                Debug.Log(" B ��ư ����");
                Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                onFailed = false;
            }
            yield return new WaitForSeconds(0); // _time ��ŭ �����ٰ�
            if (onFailed)
            {
                StartCoroutine(Clean()); 
            }

        }
    /*
    public void Clean()
    {    
        Debug.Log(" B ��ư ���� npc Text ������");
        Canvas.transform.localPosition = Canvas.transform.localPosition + new Vector3(0f, 100f, 0f);             
    }
    */
}
