using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintBrush : MonoBehaviour
{
    [SerializeField] private GameObject ironPowder; // ö����
    [SerializeField] private GameObject fluorescencePowder; // ��������
    [SerializeField] private GameObject fluorescenceRedPowder; // ���� ��������
    [SerializeField] private ParticleSystem ironParticle; // ö���� ��ƼŬ
    [SerializeField] private ParticleSystem fluorescenceParticle; // �������� ��ƼŬ
    [SerializeField] private ParticleSystem fluorescenceRedParticle; // ���� �������� ��ƼŬ

    // [SerializeField] private GameObject soju_powder; // ���ֺ� �Ŀ�� �����ߵ� ��ġ
    [SerializeField] private GameObject fingerPrint_overed; // ���� �����ϰ� ���� ���
    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ

    public bool isEquiped; // �̹� �Ŀ�� ������ ���
    public FingerPrintPowder.powderType p_type; // �Ŀ�� Ÿ��

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
    }

    // ö���縦 �׿� ���� ���
    private void IronPowder_equip()
    {
        ironPowder.SetActive(true);
        ironParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����
        p_type = FingerPrintPowder.powderType.ironPowder;
    }

    // �������縦 �׿� ���� ���
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.SetActive(true);
        fluorescenceParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����
        p_type = FingerPrintPowder.powderType.fluorescencePowder;
    }

    // ���� �������縦 �׿� ���� ���
    private void FluorescenceRedPowder_equip()
    {
        fluorescenceRedPowder.SetActive(true);
        fluorescenceRedParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����
        p_type = FingerPrintPowder.powderType.fluorescenceRedPowder;
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
                case FingerPrintPowder.powderType.fluorescenceRedPowder:
                    FluorescenceRedPowder_equip();
                    break;
            }
        }

        else // ���� ������������ ����
        {
            isEquiped = false;
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����

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
                case FingerPrintPowder.powderType.fluorescenceRedPowder:
                    fluorescenceRedPowder.SetActive(false);
                    fluorescenceRedParticle.Play();
                    break;
            }

            p_type = FingerPrintPowder.powderType.none;


            
        }



    }


    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
