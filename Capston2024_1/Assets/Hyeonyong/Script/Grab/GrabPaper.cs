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
            Debug.Log("종이와 닿았다.");
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
            Debug.Log("종이와 닿았다.");
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        // if (other.CompareTag("Paper") || other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        if (other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        {
            // 코루틴 중단
            //StopCoroutine(onGrabPaper());
            grab = false;
            Debug.Log("코루틴 중단");
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
            StartCoroutine(onGrabPaper()); // 재귀적으로 코루틴 실행
        }
    }

    */


    private void GrabOnHand() 
    {
        Debug.Log("종이를 잡겠다.");
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
    private void PutDownPaper()//카메라와 오른손의 자식관계를 해제한다.
    {
        grab = false;
        onPaper = false;
        Debug.Log("종이를 놓았다.");
        paper.transform.SetParent(null);
        PE = null;
        paper = null;

        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_1);
    }
    
}
