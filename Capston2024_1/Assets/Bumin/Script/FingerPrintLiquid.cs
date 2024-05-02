using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquid : MonoBehaviour
{
    public bool paperTriggered = false; // Paper���� �浹�� �����ϱ� ���� ����
    public bool hairLiquidTriggered = false; // Iron_Liquid���� �浹�� �����ϱ� ���� ����
    public bool liquidTriggered = false; // Liquid���� �浹�� �����ϱ� ���� ����

    // Paper�� Iron_Liquid�� �浹�� �����ϴ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            paperTriggered = true; // Paper���� �浹�� �߻������� ǥ��
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            hairLiquidTriggered = true; // Iron_Liquid���� �浹�� �߻������� ǥ��
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true; // Liquid���� �浹�� �߻������� ǥ��
        }

        CheckTriggered(); // �浹�� üũ�Ͽ� ���� ���� ����
    }

    // Paper�� Iron_Liquid ��� �浹�ߴ��� Ȯ���Ͽ� ���� ���� �����ϴ� �޼���
    private void CheckTriggered()
    {
        // Paper�� Iron_Liquid ��� �浹�� ���
        if (paperTriggered && hairLiquidTriggered && liquidTriggered)
        {
            StartCoroutine(TriggerEffect()); // ���� ������ ���� �ڷ�ƾ ����
        }
    }

    // ���̵� �� ȿ���� �����ϴ� �ڷ�ƾ �޼���
    private IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(5f);
        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f); // ���̵� �� ȿ���� ����
        Debug.Log("Finger Liquid Clear NPC Set"); // ���̵� �� ȿ���� ����Ǿ����� �α׷� ���
    }
}
