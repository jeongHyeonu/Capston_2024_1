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


    private PackingEvidence PE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
           // onPaper = false;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {

            PutDownPaper();
          //  onPaper = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Paper"))
        if (other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        {
            paper = other.gameObject;
            grab = true;
            //StartCoroutine(onGrabPaper());
            Debug.Log("���̿� ��Ҵ�.");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("Paper")||other.tag=="RECEIPT"||other.tag=="ENVELOPE")
        if (other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        {
            paper = other.gameObject;
            grab = true;
            //StartCoroutine(onGrabPaper());
            Debug.Log("���̿� ��Ҵ�.");
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        // if (other.CompareTag("Paper") || other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        if (other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        {
            // �ڷ�ƾ �ߴ�
            //StopCoroutine(onGrabPaper());
            grab = false;
            Debug.Log("�ڷ�ƾ �ߴ�");
            paper = null;
        }
    }


    /*
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

    */


    private void GrabOnHand() 
    {
        Debug.Log("���̸� ��ڴ�.");
        onPaper = true;
        paper.transform.SetParent(pincett);
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.PINSET_PICK);

        if (paper.tag == "RECEIPT") 
        {
            paper.transform.localPosition = new Vector3(0.05f, 0f, -0.15f);
            paper.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            PE = paper.GetComponent<PackingEvidence>();
            PE.OnGrab();


        }
        if (paper.tag == "ENVELOPE")
        {
            paper.transform.localPosition = new Vector3(0.00f, 0f, -0.15f);
            paper.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

            PE = paper.GetComponent<PackingEvidence>();
            PE.OnGrab();
        }
        /*
        paper.transform.localPosition = new Vector3(0f, 0f, -0.15f);
        paper.transform.localRotation = Quaternion.Euler(0f,0f, 90f);
        */
        //paper.transform.Rotate(90f, 0f, 0f);
        //Camera.transform.position = RightHand.transform.position;
    }
    private void PutDownPaper()//ī�޶�� �������� �ڽİ��踦 �����Ѵ�.
    {
        grab = false;
        onPaper = false;
        Debug.Log("���̸� ���Ҵ�.");
        paper.transform.SetParent(null);
        PE = null;
        paper = null;

        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_1);
    }
    
}
