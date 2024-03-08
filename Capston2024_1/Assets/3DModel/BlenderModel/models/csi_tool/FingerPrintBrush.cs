using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintBrush : MonoBehaviour
{
    [SerializeField] private GameObject ironPowder; // ö����
    [SerializeField] private GameObject fluorescencePowder; // ��������
    [SerializeField] private ParticleSystem ironParticle; // ö���� ��ƼŬ
    [SerializeField] private ParticleSystem fluorescenceParticle; // �������� ��ƼŬ

    // [SerializeField] private GameObject soju_powder; // ���ֺ� �Ŀ�� �����ߵ� ��ġ
    [SerializeField] private GameObject soju_fingerPrint; // ���ֺ��� ���� ö���� ����
    [SerializeField] GameObject originPos; // ���� ��ü �����ߴ� ��ġ

    public bool isEquiped; // �̹� �Ŀ�� ������ ���
    public FingerPrintPowder.powderType p_type; // �Ŀ�� Ÿ��

    // ö���縦 �׿� ���� ���
    private void IronPowder_equip()
    {
        ironPowder.gameObject.SetActive(true);
        ironParticle.Play();
        p_type = FingerPrintPowder.powderType.ironPowder;
    }

    // �������縦 �׿� ���� ���
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.gameObject.SetActive(true);
        fluorescenceParticle.Play();
        p_type = FingerPrintPowder.powderType.fluorescencePowder;
    }

    // �� ���¿� ���� �׿� ���� ���� �Ǵ� �׿� ������ ���� �߻�, 
    // ��Ʈ�ѷ� Trigger ��ư ������ ����
    public void EquipOrEmitPowder()
    {
        if (!isEquiped) // ���� �� ������������ ����
        {
            if (p_type == FingerPrintPowder.powderType.none) return;
            isEquiped = true;

            switch (p_type)
            {
                case FingerPrintPowder.powderType.ironPowder:
                    IronPowder_equip();
                    break;
                case FingerPrintPowder.powderType.fluorescencePowder:
                    FluorescencePowder_equip();
                    break;
            }
        }

        else // ���� ������������ �߻�
        {
            isEquiped = false;

            switch (p_type)
            {
                case FingerPrintPowder.powderType.ironPowder:
                    ironPowder.SetActive(false);
                    ironParticle.Play();
                    break;
                case FingerPrintPowder.powderType.fluorescencePowder:
                    fluorescencePowder.SetActive(false);
                    fluorescenceParticle.Play();
                    break;
            }

            p_type = FingerPrintPowder.powderType.none;


            
        }



    }


    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos.transform.position;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
