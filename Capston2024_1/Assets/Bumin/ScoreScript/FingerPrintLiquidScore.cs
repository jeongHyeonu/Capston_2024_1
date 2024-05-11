using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquidScore : MonoBehaviour
{
    public bool paperTriggered = false;
    public bool hairLiquidTriggered = false;
    public bool liquidTriggered = false;

    private float hairLiquidTriggerTime; // Ʈ���ſ� ���� �ð��� ����� ����

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
                liquidScoreBoard.score4.text = "15";
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
        yield return new WaitForSeconds(20f);
        if (!hairLiquidTriggered)
        {
            hairLiquidTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            if (liquidScoreBoard != null)
            {
                liquidScoreBoard.score5.text = "15";
                if (paperTriggered && hairLiquidTriggered && liquidTriggered)
                {
                    StartCoroutine(TriggerEffect());
                }
            }
        }
    }


    private IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(5f);
        // ���̵� �� ȿ�� ����
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}
