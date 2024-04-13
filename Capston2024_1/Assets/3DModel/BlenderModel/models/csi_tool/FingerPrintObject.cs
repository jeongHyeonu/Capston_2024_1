using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder;

// ���� �˻� ��� �ο��� ��ũ��Ʈ
// -----------------------------------------------
// ���ֺ� ������ �ο��� ��ũ��Ʈ, ö���� �ڼ��� �÷����� ��� ������ �巯��
// ��� ������ �ο��� ��ũ��Ʈ, �������� �ڼ��� �÷����� ��� ������ �巯��

public class FingerPrintObject : MonoBehaviour
{
    public bool isVisible = false;
    [SerializeField] private ObjectType object_type;
    [SerializeField] private TutorialCamera tutoCam;

    [SerializeField] GameObject tutoFourthBoard;

    enum ObjectType
    {
        soju,
        knife,
    }

    // ���ֺ� ������ Ʈ���� Enter�� �Ǵ� ��� ������ Ʈ���� Enter�� ����
    private void OnTriggerEnter(Collider other)
    {
        if (isVisible == true) return; // ���� ���̴� ���¸� ����X

        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            if(brushObj.p_type == powderType.ironPowder && object_type == ObjectType.soju)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
                tutoCam?.secondStep_ON();
                TutorialUX.Instance.SojuHologramOFF();
                tutoFourthBoard?.SetActive(true);
            }

            if (brushObj.p_type == powderType.fluorescencePowder && object_type == ObjectType.knife)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
                //TutorialUX.Instance.NextHologram();
            }
        }
    }
}
