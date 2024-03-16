using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 테이프에 부여할 스크립트 - 소주병 지문에 닿으면 실행
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape_soju; // 프리팹
    [SerializeField] GameObject fingerPrintTape_knife; // 프리팹

    [SerializeField] GameObject fingerPrintOnSoju; // 소주병 위에 있는 지문
    [SerializeField] GameObject fingerPrintOnKnife; // 흉기 위에 있는 지문  

    [SerializeField] GameObject rightHand; // 오른손위치
    [SerializeField] GameObject leftHand; // 왼손위치

    [SerializeField] GameObject indicatorHand; // ux, 지문에 손 갖다댈 경우 표시자
    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치

    [SerializeField] FingerPrintPaper fp_paper; // 전사지
    
    bool isTapeOnSoju = false;
    bool isTapeOnKnife = false;

    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // 소주병 위에 있는 지문일때
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintObject>().isVisible == false) return; // 지문이 아직 드러나지 않았다면 실행X

            // 코루틴 실행
            isTapeOnSoju = true;
            StartCoroutine(HandCheckCoroutine_soju());

            //ux
            indicatorHand.SetActive(true);
        }

        if (other.gameObject == fingerPrintOnKnife) // 흉기 위에 있는 지문일때
        {
            if (fingerPrintOnKnife.GetComponent<FingerPrintObject>().isVisible == false) return; // 지문이 아직 드러나지 않았다면 실행X

            // 코루틴 실행
            isTapeOnKnife = true;
            StartCoroutine(HandCheckCoroutine_knife());

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
            StopCoroutine(HandCheckCoroutine_soju());

            //ux
            indicatorHand.SetActive(false);
        }

        if (other.gameObject == fingerPrintOnKnife) // 흉기 위에 있는 지문일때
        {
            // 코루틴 중단
            isTapeOnKnife = false;
            StopCoroutine(HandCheckCoroutine_knife());

            //ux
            indicatorHand.SetActive(false);
        }
    }

    // 시간(_time)마다 손이 있는지 체크하는 코루틴 - 소주
    IEnumerator HandCheckCoroutine_soju(float _time = 0.2f)
    {
        if(isTapeOnSoju==false)
        {
            indicatorHand.SetActive(false);
            yield break; // 소주에 테이프 올려져있지 않다면 코루틴 완전 중단
        }

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // 왼손-오른손 위치 체크
        if (Vector3.Distance(indicatorHand.transform.position,leftHand.transform.position)<.08f) // 왼손과 표시자 손이 가까이 있는가 검사
        {
            isTapeOnSoju = false;
            fp_paper.fingerPrintTape_soju = Instantiate(fingerPrintTape_soju, this.transform.position,Quaternion.Euler(new Vector3(0, 0, 0)));
            fingerPrintOnSoju.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // 사운드
            TutorialUX.Instance.NextHologram(4);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time 만큼 쉬었다가
        StartCoroutine(HandCheckCoroutine_soju()); // 재귀적으로 코루틴 실행
    }

    // 시간(_time)마다 손이 있는지 체크하는 코루틴 - 흉기
    IEnumerator HandCheckCoroutine_knife(float _time = 0.2f)
    {
        if (isTapeOnKnife == false)
        {
            indicatorHand.SetActive(false);
            yield break; // 흉기에 테이프 올려져있지 않다면 코루틴 완전 중단
        }

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // 왼손-오른손 위치 체크
        if (Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position) < .08f) // 왼손과 표시자 손이 가까이 있는가 검사
        {
            isTapeOnKnife = false;
            fp_paper.fingerPrintTape_knife = Instantiate(fingerPrintTape_knife, this.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            fingerPrintOnKnife.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // 사운드
            TutorialUX.Instance.NextHologram(3);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time 만큼 쉬었다가
        StartCoroutine(HandCheckCoroutine_knife()); // 재귀적으로 코루틴 실행
    }

    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        indicatorHand.SetActive(false);
    }
}
