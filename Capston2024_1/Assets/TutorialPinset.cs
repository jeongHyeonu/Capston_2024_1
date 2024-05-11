using DG.Tweening;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPinset : MonoBehaviour
{
    [SerializeField] GameObject receipt; // 영수증
    [SerializeField] GameObject liquid; // 닌히드린 용액
    [SerializeField] GameObject targetPos; // 물에 적신 후 놓아야 할 위치

    [SerializeField] TutorialUX_Liquid t_ux; // 튜토리얼 ux

    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치
    [SerializeField] Quaternion originRot; // 원래 물체 존재했던 각도
    [SerializeField] GameObject receiptPaperTarget;
    [SerializeField] GameObject paper;

    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
        originRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == receipt)
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_3);
            t_ux.TutorialStep(1);
            receipt.transform.SetParent(transform);
            receipt.transform.localPosition = new Vector3(0, 0, -0.1f);
            receipt.transform.localRotation = Quaternion.Euler(new Vector3(0,0,-90f));
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
            target.transform.localPosition = new Vector3(0,-.005f,0); // 이후 하드코딩.. ㅈㅅ
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            paper.transform.DOMove(receiptPaperTarget.transform.position,2f).SetDelay(1f);
            t_ux.TutorialStep(3);
        }
    }

    // 손 놓으면 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
