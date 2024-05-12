using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FingerPrintPowder;

// ���� �˻� ��� �ο��� ��ũ��Ʈ
public class FingerPrintObject : MonoBehaviour
{
    public enum ObjectType
    {
        iron,
        flour,
        redFlour,
        none,
    }

    public bool isVisible = false;
    public ObjectType obj_type = ObjectType.none; // ������ �������� � ������ üũ

    [SerializeField] powderType answerPowder;
    [SerializeField] TextMeshProUGUI targetScore1;
    [SerializeField] TextMeshProUGUI targetScore2;
    [SerializeField] GameObject rulerAndCard;
    [SerializeField] Material[] mat = new Material[3];

    // ���ֺ� ������ Ʈ���� Enter�� �Ǵ� ��� ������ Ʈ���� Enter�� ����
    private void OnTriggerEnter(Collider other)
    {

        // ���� �� ���̴� ���¶��, ������ ��ü �������� ���� �巯��
        if (isVisible==false && other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            // ����1, ������ ���� �и��� �����°�?
            if (!brushObj.isStrong) targetScore1.text = "15";

            // ����2, �˸��� �� �и��� �����°�?
            if (brushObj.p_type == answerPowder) targetScore2.text = "15";

            if (brushObj.p_type == powderType.ironPowder) // ö���� ��������, ���͸��� ����
            {
                obj_type = ObjectType.iron;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
            }

            if (brushObj.p_type == powderType.fluorescencePowder) // �������� ��������, ���͸��� ����
            {
                obj_type = ObjectType.flour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder) // �������� ��������, ���͸��� ����
            {
                obj_type = ObjectType.redFlour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[2];
            }

            // ���� ���̰Բ�
            this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
            isVisible = true; // ���߿� �������� ä���, ������ �巯������ ���ΰ� true�϶� ä�� ����
            rulerAndCard?.SetActive(true); // ���� ���̸� ��/ī�� ����

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_3); // ����
        }
    }
}
