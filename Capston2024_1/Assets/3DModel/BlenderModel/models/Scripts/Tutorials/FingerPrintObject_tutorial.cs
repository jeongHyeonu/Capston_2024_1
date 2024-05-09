using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder_tutorial;

// ���� �˻� ��� �ο��� ��ũ��Ʈ
// -----------------------------------------------
// ���ֺ� ������ �ο��� ��ũ��Ʈ, ö���� �ڼ��� �÷����� ��� ������ �巯��
// ��� ������ �ο��� ��ũ��Ʈ, �������� �ڼ��� �÷����� ��� ������ �巯��

public class FingerPrintObject_tutorial : MonoBehaviour
{
    public bool isVisible = false;
    [SerializeField] private ObjectType object_type;
    [SerializeField] private TutorialCamera tutoCam;

    [SerializeField] GameObject tutoFourthBoard;
    [SerializeField] GameObject flashLightGhostHand;
    [SerializeField] GameObject rulerAndCard;

    enum ObjectType
    {
        soju,
        knife,
        cup
    }

    // ���ֺ� ������ Ʈ���� Enter�� �Ǵ� ��� ������ Ʈ���� Enter�� ����
    private void OnTriggerEnter(Collider other)
    {
        // ���� ���̴� ���¸�, ������ ������� ���� ������ ����
        if (isVisible == true)
        {
            //���Ѵ�� �ϵ��ڵ�.. ����
            if (this.object_type==ObjectType.cup && other.gameObject.name == "fingerprint_kit_01.tape")
            {
                GetComponent<MeshRenderer>().enabled = false;  
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush_tutorial brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush_tutorial>();
            if (brushObj.isStrong == true) return; // �и� ���� �ʹ� �ظ� ���� X

            if(brushObj.p_type == powderType.ironPowder && object_type == ObjectType.soju)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
                TutorialUX.Instance.SojuHologramOFF();
                tutoFourthBoard?.SetActive(true);
                flashLightGhostHand?.SetActive(true);
                rulerAndCard?.SetActive(true);
            }

            if (brushObj.p_type == powderType.fluorescencePowder && object_type == ObjectType.knife)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
                //TutorialUX.Instance.NextHologram();
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder && object_type == ObjectType.cup)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
                rulerAndCard?.SetActive(true);
            }
        }
    }
}
