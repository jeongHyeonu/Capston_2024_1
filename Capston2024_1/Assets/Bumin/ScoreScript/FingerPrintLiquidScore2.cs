using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquidScore2 : MonoBehaviour
{
    public bool paperTriggered = false;
    public bool hairLiquidTriggered = false;
    public bool liquidTriggered = false;

    private float hairLiquidTriggerTime; // 트리거에 닿은 시간을 기록할 변수

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true;
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            if (liquidScoreBoard != null)
            {
                if (liquidScoreBoard.score11.text != "15") { SoundManager.Instance.PlaySFX(SoundManager.SFX_list.LIQUID_2); }; //사운드
                liquidScoreBoard.score11.text = "15";
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            hairLiquidTriggerTime = Time.time;
            StartCoroutine(CheckHairTrigger());
        }
    }

    private IEnumerator CheckHairTrigger()
    {
        yield return new WaitForSeconds(10f);
        hairLiquidTriggered = true;
        if (hairLiquidTriggered == true)
        {
            Debug.Log("체크2.");
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            liquidScoreBoard.score12.text = "15";
            if (liquidScoreBoard != null)
            {
                if ((paperTriggered && hairLiquidTriggered && liquidTriggered) == true)
                {
                    Debug.Log("체크4.");
                    StartCoroutine(TriggerEffect());
                }
            }
        }
    }


    private IEnumerator TriggerEffect()
    {
        Debug.Log("체크5.");
        yield return new WaitForSeconds(5f);
        // 페이드 인 효과 적용
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}