using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintBrush_tutorial : MonoBehaviour
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
    public bool isStrong; // �и� ���� - �и� ó�� ������ ��� true, �ѹ� �и� true, �и� �ι� �и� false
    public FingerPrintPowder_tutorial.powderType p_type; // �Ŀ�� Ÿ��

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
        p_type = FingerPrintPowder_tutorial.powderType.ironPowder;
        isStrong = true;
        ironPowder.GetComponent<MeshRenderer>().material.DOColor(new Color(.4f, .4f, .4f), 0f);
    }

    // �������縦 �׿� ���� ���
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.SetActive(true);
        fluorescenceParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����
        p_type = FingerPrintPowder_tutorial.powderType.fluorescencePowder;
        isStrong = true;
        fluorescencePowder.GetComponent<MeshRenderer>().material.DOColor(new Color(.2f, .8f, 1f), 0f);
    }

    // ���� �������縦 �׿� ���� ���
    private void FluorescenceRedPowder_equip()
    {
        fluorescenceRedPowder.SetActive(true);
        fluorescenceRedParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����
        p_type = FingerPrintPowder_tutorial.powderType.fluorescenceRedPowder;
        isStrong = true;
        fluorescenceRedPowder.GetComponent<MeshRenderer>().material.DOColor(new Color(1f, .2f, .2f), 0f);
    }

    // �� ���¿� ���� �׿� ���� ���� �Ǵ� �׿� ������ ���� �߻�, 
    // ��Ʈ�ѷ� Trigger ��ư ������ ����
    public void EquipOrEmitPowder()
    {
        if (!isEquiped) // ���� �� ������������ ����
        {
            if (p_type == FingerPrintPowder_tutorial.powderType.none) return;
            isEquiped = true;

            switch (p_type)
            {
                case FingerPrintPowder_tutorial.powderType.ironPowder:
                    IronPowder_equip();
                    TutorialUX.Instance?.NextHologram(1); // Ʃ�丮���϶�, Ȧ�α׷� ����
                    break;
                case FingerPrintPowder_tutorial.powderType.fluorescencePowder:
                    FluorescencePowder_equip();
                    break;
                case FingerPrintPowder_tutorial.powderType.fluorescenceRedPowder:
                    FluorescenceRedPowder_equip();
                    break;
            }
        }

        else // ���� ������������ ����
        {
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // ����

            switch (p_type)
            {
                case FingerPrintPowder_tutorial.powderType.ironPowder:
                    ironParticle.Play();
                    if (isStrong) { isStrong = false; ironPowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // ���͸��� ���󺹱�
                    ironPowder.SetActive(false);
                    break;
                case FingerPrintPowder_tutorial.powderType.fluorescencePowder:
                    fluorescenceParticle.Play();
                    if (isStrong) { isStrong = false; fluorescencePowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // ���͸��� ���󺹱�
                    fluorescencePowder.SetActive(false);
                    break;
                case FingerPrintPowder_tutorial.powderType.fluorescenceRedPowder:
                    fluorescenceRedParticle.Play();
                    if (isStrong) { isStrong = false; fluorescenceRedPowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // ���͸��� ���󺹱�
                    fluorescenceRedPowder.SetActive(false);
                    break;
            }

            p_type = FingerPrintPowder_tutorial.powderType.none;
            isEquiped = false;

        }



    }


    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
