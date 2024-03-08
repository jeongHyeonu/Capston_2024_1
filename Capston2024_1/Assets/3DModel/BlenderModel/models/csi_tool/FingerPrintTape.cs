using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 테이프에 부여할 스크립트 - 소주병 지문에 닿으면 실행
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape;
    [SerializeField] GameObject fingerPrintOnSoju; // 소주병 위에 있는 지문

    [SerializeField] GameObject rightHand; // 오른손위치
    [SerializeField] GameObject leftHand; // 왼손위치

    [SerializeField] GameObject indicatorHand; // ux, 지문에 손 갖다댈 경우 표시자
    [SerializeField] GameObject originPos; // 원래 물체 존재했던 위치

    bool isTapeOnSoju = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // 소주병 위에 있는 지문일때
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintSoju>().isVisible == false) return; // 지문이 아직 드러나지 않았다면 실행X

            // 코루틴 실행
            isTapeOnSoju = true;
            StartCoroutine(HandCheckCoroutine());
            // Instantiate(fingerPrintTape,this.transform.position,Quaternion.Euler(Vector3.zero));
            // other.gameObject.SetActive(false);

            //ux
            indicatorHand.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // 소주병 위에 있는 지문일때
        {
            // 코루틴 중단
            isTapeOnSoju = false;
            StopCoroutine(HandCheckCoroutine());

            //ux
            indicatorHand.SetActive(false);
        }
    }

    // 시간(_time)마다 손이 있는지 체크하는 코루틴
    IEnumerator HandCheckCoroutine(float _time = 0.2f)
    {
        if(isTapeOnSoju==false) yield break; // 소주에 테이프 올려져있지 않다면 코루틴 완전 중단

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // 왼손-오른손 위치 체크
        if (Vector3.Distance(indicatorHand.transform.position,leftHand.transform.position)<.05f) // 왼손과 표시자 손이 가까이 있는가 검사
        {
            isTapeOnSoju = false;
            Instantiate(fingerPrintTape,this.transform.position,Quaternion.Euler(Vector3.zero));
            fingerPrintOnSoju.SetActive(false);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time 만큼 쉬었다가
        StartCoroutine(HandCheckCoroutine()); // 재귀적으로 코루틴 실행
    }

    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos.transform.position;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
