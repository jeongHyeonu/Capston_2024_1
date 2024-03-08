using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder;

// ���ֺ� ������ �ο��� ��ũ��Ʈ, ö���� �ڼ��� �÷����� ��� ������ �巯��
public class FingerPrintSoju : MonoBehaviour
{
    public bool isVisible = false;

    // ���ֺ� ������ Ʈ���� Enter�� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            if(brushObj.p_type == powderType.ironPowder)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
            }
        }
    }
}
