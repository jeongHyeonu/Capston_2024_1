using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera_Liquid : MonoBehaviour
{
    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    [SerializeField] Quaternion originRot; // ���� ��ü �����ߴ� ����

    [SerializeField] GameObject hologramCam;
    [SerializeField] GameObject hologramHand;

    [SerializeField] GameObject hologramPinset;
    [SerializeField] GameObject pinset;

    [SerializeField] GameObject clearBoard;

    [SerializeField] TutorialFlash tutoFlash;
    [SerializeField] GameObject hologramFlash;

    [SerializeField] TutorialUX_Liquid t_ux;

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
        if (OVRInput.GetDown(OVRInput.Button.One))
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

        hologramCam.SetActive(true);
    }

    // ī�޶� ��ȣ�ۿ�
    public void InteractCamera()
    {

        if (isCameraTime == false) return;

        if (Vector3.Distance(hologramCam.transform.position, this.transform.position) < .1f)
        {
            if (firstStep)
            {
                t_ux.TutorialStep(0);
                firstStep = false;
                pinset.GetComponent<CapsuleCollider>().enabled = true;
            }
            if (secondStep)
            {
                if (tutoFlash.isGrabbing == false) return; // �÷��� �� ���߰� ������ ����X
                t_ux.TutorialStep(5);
                hologramFlash.SetActive(false);
                secondStep = false;
            }

            isCameraTime = false;
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);
            hologramCam.SetActive(false);
        };

    }

    public void secondStep_ON()
    {
        isCameraTime = true;
        secondStep = true;
        hologramHand.SetActive(true);
        hologramCam.transform.position += new Vector3(.2f, 0, 0); // �ϵ��ڵ� ����.. �Ф�
    }

    // ī�޶� �� ������ ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
        hologramFlash.SetActive(false); // Ȧ�α׷� �÷��� off
    }
}
