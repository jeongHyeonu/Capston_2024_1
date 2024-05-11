using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquidScore2 : MonoBehaviour
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
        Debug.Log("üũ0.");
        yield return new WaitForSeconds(5f);
        Debug.Log("üũ1.");
        if (hairLiquidTriggered)
        {
            Debug.Log("üũ2.");
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            if (liquidScoreBoard != null)
            {
                liquidScoreBoard.score12.text = "15";
                hairLiquidTriggered = true;
                Debug.Log("üũ3.");
                if ((paperTriggered && hairLiquidTriggered && liquidTriggered) == true)
                {
                    Debug.Log("üũ4.");
                    StartCoroutine(TriggerEffect());
                }
            }
        }
    }


    private IEnumerator TriggerEffect()
    {
        Debug.Log("üũ5.");
        yield return new WaitForSeconds(5f);
        // ���̵� �� ȿ�� ����
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}