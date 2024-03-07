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

    [SerializeField] private GameObject soju_powder; // ���ֺ� �Ŀ�� �����ߵ� ��ġ
    [SerializeField] private GameObject soju_fingerPrint; // ���ֺ��� ���� ö���� ����

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
            // ���ֺ� �����̿� �ְ�, ���ֺ��� �Ŀ���� �̹� ������(active���� = true) ��� 
            if (Vector3.Distance(soju_powder.transform.position, this.transform.position) < .2f)
            {
                if(soju_powder.activeSelf==true)
                {
                    soju_powder.transform.DOScale(0f, 1f);
                    soju_fingerPrint.SetActive(true);
                    isEquiped = true;
                    IronPowder_equip();
                    return;
                }
            }
            else if (p_type == FingerPrintPowder.powderType.none) return;
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
                    Debug.Log(Vector3.Distance(soju_powder.transform.position, this.transform.position));
                    // �߻��� ��ġ ��ó�� ���ֺ��� �ִ� ���
                    if(Vector3.Distance(soju_powder.transform.position,this.transform.position)<.2f)
                    {
                        if (soju_powder.activeSelf == false)
                        {
                            soju_powder.SetActive(true);
                            soju_powder.transform.DOScale(1f, 1f);
                        }
                    }
                    break;
                case FingerPrintPowder.powderType.fluorescencePowder:
                    fluorescencePowder.SetActive(false);
                    fluorescenceParticle.Play();
                    break;
            }

            p_type = FingerPrintPowder.powderType.none;


            
        }



    }
}
