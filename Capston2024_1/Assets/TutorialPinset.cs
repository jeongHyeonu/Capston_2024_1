using DG.Tweening;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPinset : MonoBehaviour
{
    [SerializeField] GameObject receipt; // ������
    [SerializeField] GameObject liquid; // �����帰 ���
    [SerializeField] GameObject targetPos; // ���� ���� �� ���ƾ� �� ��ġ

    [SerializeField] TutorialUX_Liquid t_ux; // Ʃ�丮�� ux

    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    [SerializeField] Quaternion originRot; // ���� ��ü �����ߴ� ����
    [SerializeField] GameObject receiptPaperTarget;
    [SerializeField] GameObject paper;

    bool isGrabAble = false;
    bool isGrabbing = false;

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
        originRot = transform.rotation;
    }

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && isGrabAble == true)
        {
            GrabOnHand();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && isGrabAble == true)
        {
            GrabOnHand();
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && isGrabbing == true)
        {
            PutDownPaper();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && isGrabbing == true)
        {
            PutDownPaper();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == receipt)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_3);
            isGrabAble = true;
        }
        if (other.gameObject == liquid)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.LIQUID_1);
            t_ux.TutorialStep(2);
        }
        if (other.gameObject == targetPos && isGrabbing)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_2);
            GetComponent<GrabInteractable>().enabled = false;
            GetComponent<Grabbable>().enabled = false;
            MoveOriginPos();
            GameObject target = transform.GetChild(0).gameObject;
            target.transform.SetParent(receiptPaperTarget.transform); // �ɼ����� ���� ������ �θ�-�ڽ� ���� ����
            target.transform.localPosition = new Vector3(0,-.005f,0); // ���� �ϵ��ڵ�.. ����
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            paper.transform.DOMove(receiptPaperTarget.transform.position,2f).SetDelay(1f);
            t_ux.TutorialStep(3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == receipt)
        {
            isGrabAble = false;
        }
    }

    private void GrabOnHand() 
    {
        t_ux.TutorialStep(1);
        receipt.transform.SetParent(transform);
        receipt.transform.localPosition = new Vector3(0, 0, -0.1f);
        receipt.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90f));
        isGrabbing = true;
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.PINSET_PICK);
    }

    private void PutDownPaper()
    {
        receipt.transform.SetParent(null);
        isGrabbing = false;
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_1);
    }

    // �� ������ ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
