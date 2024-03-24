using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera : MonoBehaviour
{
    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    [SerializeField] Quaternion originRot; // ���� ��ü �����ߴ� ����

    [SerializeField] GameObject hologramCam;
    [SerializeField] GameObject hologramHand;

    [SerializeField] GameObject powderLid;
    [SerializeField] GameObject tape;

    // ī�޶� ���� ���� �� ��Ȳ�� �ƴ��� �˻��ϴ� ����
    public bool isCameraTime = true;

    public bool firstStep = true;
    public bool secondStep = false;

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
        originRot = transform.rotation;
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (isCameraTime == false) return;
            InteractCamera();
        }
    }

    // ī�޶� ������ Ȧ�α׷� ����
    public void HologramCamera_ON()
    {
        if (isCameraTime == false) return;
        hologramCam.SetActive(true);
    }

    // ī�޶� ��ȣ�ۿ�
    public void InteractCamera()
    {
        if (Vector3.Distance(hologramCam.transform.position, this.transform.position) > .1f) return;
        isCameraTime = false;

        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);
        hologramCam.SetActive(false);
        if (firstStep) { 
            TutorialUX.Instance.hologramObjects[0].SetActive(true); 
            firstStep = false;
            powderLid.GetComponent<BoxCollider>().enabled = true;
        }
        if (secondStep) { 
            TutorialUX.Instance.NextHologram(2);
            secondStep = false; 
            tape.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void secondStep_ON()
    {
        isCameraTime = true;
        secondStep = true;
        hologramHand.SetActive(true);
    }

    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
