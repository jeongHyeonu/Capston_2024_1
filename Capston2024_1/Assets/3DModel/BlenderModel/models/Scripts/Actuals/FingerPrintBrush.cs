using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintBrush : MonoBehaviour
{
    [SerializeField] private GameObject ironPowder; // 철가루
    [SerializeField] private GameObject fluorescencePowder; // 형광가루
    [SerializeField] private GameObject fluorescenceRedPowder; // 형광 적색가루
    [SerializeField] private ParticleSystem ironParticle; // 철가루 파티클
    [SerializeField] private ParticleSystem fluorescenceParticle; // 형광가루 파티클
    [SerializeField] private ParticleSystem fluorescenceRedParticle; // 형광 적색가루 파티클

    // [SerializeField] private GameObject soju_powder; // 소주병 파우더 묻혀야될 위치
    [SerializeField] private GameObject fingerPrint_overed; // 지문 과도하게 입힐 경우
    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치

    public bool isEquiped; // 이미 파우더 입혀진 경우
    public bool isStrong; // 분말 강도 - 분말 처음 묻히는 경우 true, 한번 털면 true, 분말 두번 털면 false
    public FingerPrintPowder.powderType p_type; // 파우더 타입

    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
    }

    // 철가루를 붓에 묻힐 경우
    private void IronPowder_equip()
    {
        ironPowder.SetActive(true);
        ironParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
        p_type = FingerPrintPowder.powderType.ironPowder;
        isStrong = true;
        ironPowder.GetComponent<MeshRenderer>().material.DOColor(new Color(.4f, .4f, .4f), 0f);
    }

    // 형광가루를 붓에 묻힐 경우
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.SetActive(true);
        fluorescenceParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
        p_type = FingerPrintPowder.powderType.fluorescencePowder;
        isStrong = true;
        fluorescencePowder.GetComponent<MeshRenderer>().material.DOColor(new Color(.2f, .8f, 1f), 0f);
    }

    // 빨간 형광가루를 붓에 묻힐 경우
    private void FluorescenceRedPowder_equip()
    {
        fluorescenceRedPowder.SetActive(true);
        fluorescenceRedParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
        p_type = FingerPrintPowder.powderType.fluorescenceRedPowder;
        isStrong = true;
        fluorescenceRedPowder.GetComponent<MeshRenderer>().material.DOColor(new Color(1f, .2f, .2f), 0f);
    }

    // 붓 상태에 따라 붓에 가루 장착 또는 붓에 묻혀진 가루 발사, 
    // 컨트롤러 Trigger 버튼 누르면 수행
    public void EquipOrEmitPowder()
    {
        if (!isEquiped) // 가루 안 묻혀져있으면 장착
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

        else // 가루 묻혀져있으면 방출
        {
            isEquiped = false;
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드

            switch (p_type)
            {
                case FingerPrintPowder.powderType.ironPowder:
                    ironPowder.SetActive(false);
                    if (isStrong) { isStrong = false; ironPowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // 메터리얼 원상복귀
                    ironParticle.Play();
                    break;
                case FingerPrintPowder.powderType.fluorescencePowder:
                    fluorescencePowder.SetActive(false);
                    if (isStrong) { isStrong = false; fluorescencePowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // 메터리얼 원상복귀
                    fluorescenceParticle.Play();
                    break;
                case FingerPrintPowder.powderType.fluorescenceRedPowder:
                    fluorescenceRedPowder.SetActive(false);
                    if (isStrong) { isStrong = false; fluorescenceRedPowder.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.2f); return; } // 메터리얼 원상복귀
                    fluorescenceRedParticle.Play();
                    break;
            }

            p_type = FingerPrintPowder.powderType.none;


            
        }



    }


    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
