using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabPaper : MonoBehaviour
{

    public bool onPaper = false;
    public bool grab = false;
    public Transform pincett;

    public GameObject paper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            paper = other.gameObject;
            grab = true;
            StartCoroutine(onGrabPaper());
            Debug.Log("���̿� ��Ҵ�.");
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Paper"))
        {
            // �ڷ�ƾ �ߴ�
            StopCoroutine(onGrabPaper());
            grab = false;
            Debug.Log("�ڷ�ƾ �ߴ�");
            paper = null;
        }
    }



    IEnumerator onGrabPaper()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && grab == true)
        {
            GrabOnHand();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && grab == true)
        {
            GrabOnHand();
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {

            PutDownPaper();
            onPaper = false;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {

            PutDownPaper();
            onPaper = false;
        }

        yield return new WaitForSeconds(0);
        if (grab == true)
        {
            StartCoroutine(onGrabPaper()); // ��������� �ڷ�ƾ ����
        }
    }




    private void GrabOnHand() // ī�޶� �������� �ڽ����� �ΰ� ��ġ�� �̵���Ų��.
    {
        Debug.Log("���̸� ��ڴ�.");
        onPaper = true;
        paper.transform.SetParent(pincett);
        paper.transform.localPosition = new Vector3(0f, 1.2f, 0f);
        paper.transform.localRotation = Quaternion.Euler(-90.0f,0f, 0f);
        //paper.transform.Rotate(90f, 0f, 0f);
        //Camera.transform.position = RightHand.transform.position;
    }
    private void PutDownPaper()//ī�޶�� �������� �ڽİ��踦 �����Ѵ�.
    {
        onPaper = false;
        Debug.Log("���̸� ���Ҵ�.");
        paper.transform.SetParent(null);
    }

}
