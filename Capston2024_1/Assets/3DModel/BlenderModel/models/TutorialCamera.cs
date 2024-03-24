using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera : MonoBehaviour
{
    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치
    [SerializeField] Quaternion originRot; // 원래 물체 존재했던 각도

    [SerializeField] GameObject hologramCam;
    [SerializeField] GameObject hologramHand;

    [SerializeField] GameObject powderLid;
    [SerializeField] GameObject tape;

    // 카메라 사진 찍어야 될 상황이 아닌지 검사하는 변수
    public bool isCameraTime = true;

    public bool firstStep = true;
    public bool secondStep = false;

    private void Start() // 원래 물체 존재했던 위치 기억
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

    // 카메라 잡으면 홀로그램 등장
    public void HologramCamera_ON()
    {
        if (isCameraTime == false) return;
        hologramCam.SetActive(true);
    }

    // 카메라 상호작용
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

    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }
}
