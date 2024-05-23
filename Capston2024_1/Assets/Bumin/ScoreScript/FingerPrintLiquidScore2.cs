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
                if (liquidScoreBoard.score11.text != "15") { SoundManager.Instance.PlaySFX(SoundManager.SFX_list.LIQUID_2); }; //����
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
            Debug.Log("üũ2.");
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>();
            liquidScoreBoard.score12.text = "15";
            if (liquidScoreBoard != null)
            {
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