using DG.Tweening;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialGrabPaper : MonoBehaviour
{
    [SerializeField] GameObject receipt; // ������
    [SerializeField] GameObject liquid; // �����帰 ���
    [SerializeField] GameObject targetPos; // ���� ���� �� ���ƾ� �� ��ġ

    [SerializeField] TutorialUX_Liquid t_ux; // Ʃ�丮�� ux

    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    [SerializeField] Quaternion originRot; // ���� ��ü �����ߴ� ����
    [SerializeField] GameObject receiptPaperTarget;
    [SerializeField] GameObject paper;


    public bool onPaper = false;
    public bool grab = false;
    public Transform pincett;

    public GameObject Mypaper;


    private PackingEvidence PE;
    // Start is called before the first frame update
    private void Start() // ���� ��ü �����ߴ� ��ġ ���
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
            Debug.Log("���̿� ��Ҵ�.");


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
            target.transform.SetParent(receiptPaperTarget.transform); // �ɼ����� ���� ������ �θ�-�ڽ� ���� ����
            target.transform.localPosition = new Vector3(0, -.005f, 0); // ���� �ϵ��ڵ�.. ����
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
            // �ڷ�ƾ �ߴ�
            //StopCoroutine(onGrabPaper());
            grab = false;
            Debug.Log("�ڷ�ƾ �ߴ�");
            Mypaper = null;
            PutDownPaper();
        }
    }
    

    private void GrabOnHand() // ī�޶� �������� �ڽ����� �ΰ� ��ġ�� �̵���Ų��.
    {
        Debug.Log("���̸� ��ڴ�.");
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
    private void PutDownPaper()//ī�޶�� �������� �ڽİ��踦 �����Ѵ�.
    {
        grab = false;
        onPaper = false;
        Debug.Log("���̸� ���Ҵ�.");
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
            target.transform.SetParent(receiptPaperTarget.transform); // �ɼ����� ���� ������ �θ�-�ڽ� ���� ����
            target.transform.localPosition = new Vector3(0, -.005f, 0); // ���� �ϵ��ڵ�.. ����
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            paper.transform.DOMove(receiptPaperTarget.transform.position, 2f).SetDelay(1f);
            t_ux.TutorialStep(3);
        }
    }
    */
    // �� ������ ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
