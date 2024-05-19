using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 테이프에 부여할 스크립트 - 소주병 지문에 닿으면 실행
public class FingerPrintTape_tutorial : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape_soju; // 프리팹
    [SerializeField] GameObject fingerPrintTape_knife; // 프리팹

    [SerializeField] GameObject fingerPrintOnSoju; // 소주병 위에 있는 지문
    [SerializeField] GameObject fingerPrintOnKnife; // 흉기 위에 있는 지문  

    [SerializeField] GameObject rightHand; // 오른손위치
    [SerializeField] GameObject leftHand; // 왼손위치

    [SerializeField] GameObject indicatorHand; // ux, 지문에 손 갖다댈 경우 표시자
    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치

    [SerializeField] FingerPrintPaper_tutorial fp_paper; // 전사지


    public bool onTape = false; //0426자 양현용 : 테이프 생성 판단용으로 추가
    

    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // 소주병 위에 있는 지문일때
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintObject_tutorial>().isVisible == false) return; // 지문이 아직 드러나지 않았다면 실행X

            fp_paper.fingerPrintTape_soju = Instantiate(fingerPrintTape_soju, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            fingerPrintOnSoju.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // 사운드
            TutorialUX.Instance.NextHologram(4);
        }
    }


    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        indicatorHand.SetActive(false);
    }
}
