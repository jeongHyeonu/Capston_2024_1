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

    [SerializeField] GameObject clearBoard;
    [SerializeField] GameObject lastHologramCam;

    [SerializeField] TutorialFlash tutoFlash;
    [SerializeField] GameObject hologramFlash;

    // ī�޶� ���� ���� �� ��Ȳ�� �ƴ��� �˻��ϴ� ����
    public bool isCameraTime = true;

    public bool firstStep = true;
    public bool secondStep = false;
    public bool lastStep = false;

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
        if (secondStep) hologramFlash.SetActive(true);

        if (lastStep)
        {
            lastHologramCam.SetActive(true);
        }
        else
        {
            hologramCam.SetActive(true);
        }
    }

    // ī�޶� ��ȣ�ۿ�
    public void InteractCamera()
    {

        if (isCameraTime == false) return;

        if (Vector3.Distance(hologramCam.transform.position, this.transform.position) < .1f)
        {
            if (firstStep)
            {
                TutorialUX.Instance.hologramObjects[0].SetActive(true);
                firstStep = false;
                powderLid.GetComponent<BoxCollider>().enabled = true;
            }
            if (secondStep)
            {
                if (tutoFlash.isGrabbing == false) return; // �÷��� �� ���߰� ������ ����X
                TutorialUX.Instance.NextHologram(2);
                hologramFlash.SetActive(false);
                secondStep = false;
                tape.GetComponent<BoxCollider>().enabled = true;
            }

            isCameraTime = false;
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);
            hologramCam.SetActive(false);
        };

        if (Vector3.Distance(lastHologramCam.transform.position, this.transform.position) < .1f)
        {
            isCameraTime = false;
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);

            if (lastStep)
            {
                clearBoard.SetActive(true);
                lastStep = false;
                enabled = false;
                lastHologramCam.SetActive(false);
            }
        };

    }

    public void secondStep_ON()
    {
        isCameraTime = true;
        secondStep = true;
        hologramHand.SetActive(true);
    }

    public void lastStep_ON()
    {
        isCameraTime = true;
        lastStep = true;
        hologramHand.SetActive(true);
    }

    // ī�޶� �� ������ ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
        hologramFlash.SetActive(false); // Ȧ�α׷� �÷��� off
    }
}
