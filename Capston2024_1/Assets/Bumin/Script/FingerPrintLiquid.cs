using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquid : MonoBehaviour
{
    public bool paperTriggered = false; // Paper와의 충돌을 추적하기 위한 변수
    public bool hairLiquidTriggered = false; // Iron_Liquid와의 충돌을 추적하기 위한 변수
    public bool liquidTriggered = false; // Liquid와의 충돌을 추적하기 위한 변수

    // Paper와 Iron_Liquid의 충돌을 감지하는 메서드
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true; // Paper와의 충돌이 발생했음을 표시
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            hairLiquidTriggered = true; // Iron_Liquid와의 충돌이 발생했음을 표시
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true; // Liquid와의 충돌이 발생했음을 표시
        }

        CheckTriggered(); // 충돌을 체크하여 실행 여부 결정
    }

    // Paper와 Iron_Liquid 모두 충돌했는지 확인하여 실행 여부 결정하는 메서드
    private void CheckTriggered()
    {
        // Paper와 Iron_Liquid 모두 충돌한 경우
        if (paperTriggered && hairLiquidTriggered && liquidTriggered)
        {
            StartCoroutine(TriggerEffect()); // 지연 실행을 위한 코루틴 시작
        }
    }

    // 페이드 인 효과를 적용하는 코루틴 메서드
    private IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(5f);
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f); // 페이드 인 효과를 적용
        Debug.Log("Finger Liquid Clear NPC Set"); // 페이드 인 효과가 적용되었음을 로그로 출력
    }
}
