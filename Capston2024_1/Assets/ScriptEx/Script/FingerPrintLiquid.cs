using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquid : MonoBehaviour
{
    private bool isTriggered = false; // 트리거가 발생했는지 여부를 추적하기 위한 변수

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Iron_Liquid") && !isTriggered)
        {
            isTriggered = true; //트리거가 발생했음을 표시


            StartCoroutine(TriggerEffect());  // 지연 실행을 위한 코루틴 시작
        }
    }

    private IEnumerator TriggerEffect()
    {

        yield return new WaitForSeconds(5f); // 0.4초 대기

        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f); // 페이드 인 효과를 적용
    }
}
