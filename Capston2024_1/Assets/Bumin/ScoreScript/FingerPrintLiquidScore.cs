using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquidScore : MonoBehaviour
{
    private bool paperTriggered = false;
    private bool hairLiquidTriggered = false;
    private bool liquidTriggered = false;

    private float hairLiquidTriggerTime; // Ʈ���ſ� ���� �ð��� ����� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true;
            LiquidScoreBoard liquidScoreBoard = FindObjectOfType<LiquidScoreBoard>(); // ���ھ� ������ ���� �ٲٴ�
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
            // Hair Ʈ���ſ� ���� �ð� ���
            hairLiquidTriggerTime = Time.deltaTime;
        }
    }

    private void Update()
    {
        // ��� Ʈ���Ű� Ȱ��ȭ�Ǿ���, Hair Ʈ���ſ� ���� �� 20�� �̻� ����� ���
        if (paperTriggered && liquidTriggered && (Time.deltaTime - hairLiquidTriggerTime >= 10f))
        {
            // ������ hairLiquidTriggered ���� �����ϰ� �׻� true�� ����
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
        // ���̵� �� ȿ�� ����
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}
