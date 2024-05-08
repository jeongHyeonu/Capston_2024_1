using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquidScore : MonoBehaviour
{
    private bool paperTriggered = false;
    private bool hairLiquidTriggered = false;
    private bool liquidTriggered = false;

    private float hairLiquidTriggerTime; // 트리거에 닿은 시간을 기록할 변수

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>(); // 스코어 보드의 점수 바꾸는
            if (liquidScoreBoard != null)
            {
                liquidScoreBoard.score3.text = "15";
            }
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            if (liquidScoreBoard != null)
            {
                liquidScoreBoard.score4.text = "15";
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            // Hair 트리거에 닿은 시간 기록
            hairLiquidTriggerTime = Time.deltaTime;
        }
    }

    private void Update()
    {
        // 모든 트리거가 활성화되었고, Hair 트리거에 닿은 후 20초 이상 경과한 경우
        if (paperTriggered && liquidTriggered && (Time.deltaTime - hairLiquidTriggerTime >= 10f))
        {
            // 기존의 hairLiquidTriggered 값을 무시하고 항상 true로 설정
            hairLiquidTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            if (liquidScoreBoard != null)
            {
                liquidScoreBoard.score5.text = "15";
            }
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
