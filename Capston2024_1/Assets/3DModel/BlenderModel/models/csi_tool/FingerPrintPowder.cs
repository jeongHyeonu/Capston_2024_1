using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintPowder : MonoBehaviour
{
    public enum powderType
    {
        ironPowder, // ö����
        fluorescencePowder, // ��������
        none, // ������ ���� ����
    }

    [SerializeField] powderType p_type;

    // �귯�� �Ŀ�� �뿡 ���� ���� ���, Ÿ�� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();
            if (brushObj.isEquiped) return; // �̹� �׿� ������ ��� ����X

            switch (p_type)
            {
                case powderType.ironPowder:
                    brushObj.p_type = powderType.ironPowder;
                    break;
                case powderType.fluorescencePowder:
                    brushObj.p_type = powderType.fluorescencePowder;
                    break;
            }
        }
    }

    // �귯�� �Ŀ�� ���� �������� ���, Ÿ�� none ���� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();
            if (brushObj.isEquiped) return; // �̹� �׿� ������ ��� ����X

            brushObj.p_type = powderType.none;
        }
    }
}
