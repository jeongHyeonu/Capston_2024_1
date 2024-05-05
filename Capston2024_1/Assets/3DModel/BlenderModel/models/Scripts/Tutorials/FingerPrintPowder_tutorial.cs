using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintPowder_tutorial : MonoBehaviour
{
    public enum powderType
    {
        ironPowder, // ö����
        fluorescencePowder, // ��������
        fluorescenceRedPowder, // ���� ��������
        silver, // ����� ����
        none, // ������ ���� ����
    }

    [SerializeField] powderType p_type;

    // �귯�� �Ŀ�� �뿡 ���� ���� ���, Ÿ�� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush_tutorial brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush_tutorial>();
            if (brushObj.isEquiped) return; // �̹� �׿� ������ ��� ����X

            switch (p_type)
            {
                case powderType.ironPowder:
                    brushObj.p_type = powderType.ironPowder;
                    break;
                case powderType.fluorescencePowder:
                    brushObj.p_type = powderType.fluorescencePowder;
                    break;
                case powderType.fluorescenceRedPowder:
                    brushObj.p_type = powderType.fluorescenceRedPowder;
                    break;
                case powderType.silver:
                    brushObj.p_type = powderType.silver;
                    break;
            }

            TutorialUX.Instance.TriggerUX_ON(this.gameObject);
        }
    }

    // �귯�� �Ŀ�� ���� �������� ���, Ÿ�� none ���� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush_tutorial brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush_tutorial>();
            if (brushObj.isEquiped) return; // �̹� �׿� ������ ��� ����X

            brushObj.p_type = powderType.none;

            TutorialUX.Instance.UX_OFF();
        }
    }
}
