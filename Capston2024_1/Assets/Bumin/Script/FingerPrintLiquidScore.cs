using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween �߰�

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
            // Paper���� �浹�� �����Ǹ� score1�� �ؽ�Ʈ�� "15"�� ����
            DontDestroy dontDestroyScript = FindObjectOfType<DontDestroy>(); // ���ھ� ������ ���� �ٲٴ�
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
        // ���̵� �� ȿ�� ����
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        Debug.Log("Finger Liquid Clear NPC Set");
    }
}


