using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquid : MonoBehaviour
{
    private bool isTriggered = false; // Ʈ���Ű� �߻��ߴ��� ���θ� �����ϱ� ���� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Iron_Liquid") && !isTriggered)
        {
            isTriggered = true; //Ʈ���Ű� �߻������� ǥ��


            StartCoroutine(TriggerEffect());  // ���� ������ ���� �ڷ�ƾ ����
        }
    }

    private IEnumerator TriggerEffect()
    {

        yield return new WaitForSeconds(5f); // 0.4�� ���

        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f); // ���̵� �� ȿ���� ����
    }
}
