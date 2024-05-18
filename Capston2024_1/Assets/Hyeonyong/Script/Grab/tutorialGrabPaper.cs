using DG.Tweening;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialGrabPaper : MonoBehaviour
{
    [SerializeField] GameObject receipt; // 영수증
    [SerializeField] GameObject liquid; // 닌히드린 용액
    [SerializeField] GameObject targetPos; // 물에 적신 후 놓아야 할 위치

    [SerializeField] TutorialUX_Liquid t_ux; // 튜토리얼 ux

    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치
    [SerializeField] Quaternion originRot; // 원래 물체 존재했던 각도
    [SerializeField] GameObject receiptPaperTarget;
    [SerializeField] GameObject paper;


    public bool onPaper = false;
    public bool grab = false;
    public Transform pincett;

    public GameObject Mypaper;


    private PackingEvidence PE;
    // Start is called before the first frame update
    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
        originRot = transform.rotation;
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
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {

            PutDownPaper();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Paper"))
        if (other.tag == "RECEIPT" || other.tag == "ENVELOPE")
        {
            Mypaper = other.gameObject;
            grab = true;
            //StartCoroutine(onGrabPaper());
            Debug.Log("종이와 닿았다.");


            ///////////////////
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_3);
            t_ux.TutorialStep(1);
        }

        if (other.gameObject == liquid)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.LIQUID_1);
            t_ux.TutorialStep(2);
        }

        if (other.gameObject == targetPos)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_2);
            GetComponent<GrabInteractable>().enabled = false;
            GetComponent<Grabbable>().enabled = false;
            MoveOriginPos();
            GameObject target = transform.GetChild(0).gameObject;
            target.transform.SetParent(receiptPaperTarget.transform); // 핀셋으로 잡은 영수증 부모-자식 관계 해제
            target.transform.localPosition = new Vector3(0, -.005f, 0); // 이후 하드코딩.. ㅈㅅ
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            paper.transform.DOMove(receiptPaperTarget.transform.position, 2f).SetDelay(1f);
            t_ux.TutorialStep(3);
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
            Mypaper = null;
            PutDownPaper();
        }
    }
    

    private void GrabOnHand() // 카메라를 오른손의 자식으로 두고 위치를 이동시킨다.
    {
        Debug.Log("종이를 잡겠다.");
        onPaper = true;
        Mypaper.transform.SetParent(pincett);
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.PINSET_PICK);

        if (Mypaper.tag == "RECEIPT")
        {
            Mypaper.transform.localPosition = new Vector3(0.05f, 0f, -0.15f);
            Mypaper.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
           // PE = Mypaper.GetComponent<PackingEvidence>();
           // PE.OnGrab();


        }
        if (paper.tag == "ENVELOPE")
        {
            Mypaper.transform.localPosition = new Vector3(0.00f, 0f, -0.15f);
            Mypaper.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

           // PE = Mypaper.GetComponent<PackingEvidence>();
           // PE.OnGrab();
        }
    }
    private void PutDownPaper()//카메라와 오른손의 자식관계를 해제한다.
    {
        grab = false;
        onPaper = false;
        Debug.Log("종이를 놓았다.");
        Mypaper.transform.SetParent(null);
      //  PE = null;
        Mypaper = null;

        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_1);
    }

    /// <summary>
    /// ///////////
    /// </summary>


    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == receipt)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_3);
            t_ux.TutorialStep(1);
            receipt.transform.SetParent(transform);
            receipt.transform.localPosition = new Vector3(0, 0, -0.1f);
            receipt.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90f));
        }
        if (other.gameObject == liquid)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.LIQUID_1);
            t_ux.TutorialStep(2);
        }
        if (other.gameObject == targetPos)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_2);
            GetComponent<GrabInteractable>().enabled = false;
            GetComponent<Grabbable>().enabled = false;
            MoveOriginPos();
            GameObject target = transform.GetChild(0).gameObject;
            target.transform.SetParent(receiptPaperTarget.transform); // 핀셋으로 잡은 영수증 부모-자식 관계 해제
            target.transform.localPosition = new Vector3(0, -.005f, 0); // 이후 하드코딩.. ㅈㅅ
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            paper.transform.DOMove(receiptPaperTarget.transform.position, 2f).SetDelay(1f);
            t_ux.TutorialStep(3);
        }
    }
    */
    // 손 놓으면 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
