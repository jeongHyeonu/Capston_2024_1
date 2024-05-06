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
            Debug.Log("종이와 닿았다.");
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Paper"))
        {
            // 코루틴 중단
            StopCoroutine(onGrabPaper());
            grab = false;
            Debug.Log("코루틴 중단");
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
            StartCoroutine(onGrabPaper()); // 재귀적으로 코루틴 실행
        }
    }




    private void GrabOnHand() // 카메라를 오른손의 자식으로 두고 위치를 이동시킨다.
    {
        Debug.Log("종이를 잡겠다.");
        onPaper = true;
        paper.transform.SetParent(pincett);
        paper.transform.localPosition = new Vector3(0f, 1.2f, 0f);
        paper.transform.localRotation = Quaternion.Euler(-90.0f,0f, 0f);
        //paper.transform.Rotate(90f, 0f, 0f);
        //Camera.transform.position = RightHand.transform.position;
    }
    private void PutDownPaper()//카메라와 오른손의 자식관계를 해제한다.
    {
        onPaper = false;
        Debug.Log("종이를 놓았다.");
        paper.transform.SetParent(null);
    }

}
