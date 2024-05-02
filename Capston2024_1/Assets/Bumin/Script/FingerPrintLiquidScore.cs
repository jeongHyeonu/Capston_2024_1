using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween 추가

public class FingerPrintLiquidScore : MonoBehaviour
{
    private bool paperTriggered = false;
    private bool hairLiquidTriggered = false;
    private bool liquidTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true;
            // Paper와의 충돌이 감지되면 score1의 텍스트를 "15"로 변경
            DontDestroy dontDestroyScript = FindObjectOfType<DontDestroy>(); // 스코어 보드의 점수 바꾸는
            if (dontDestroyScript != null)
            {
                dontDestroyScript.score1.text = "15";
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            hairLiquidTriggered = true;
            DontDestroy dontDestroyScript = FindObjectOfType<DontDestroy>();
            if (dontDestroyScript != null)
            {
                dontDestroyScript.score3.text = "15";
            }
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true;
            DontDestroy dontDestroyScript = FindObjectOfType<DontDestroy>();
            if (dontDestroyScript != null)
            {
                dontDestroyScript.score5.text = "15";
            }
        }

        CheckTriggered();
    }

    private void CheckTriggered()
    {
        if (paperTriggered && hairLiquidTriggered && liquidTriggered)
        {
            StartCoroutine(TriggerEffect());
        }
    }

    private IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(5f);
        // 페이드 인 효과 적용
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}


