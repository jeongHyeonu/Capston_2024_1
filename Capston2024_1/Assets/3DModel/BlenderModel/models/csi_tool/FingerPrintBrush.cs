using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintBrush : MonoBehaviour
{
    [SerializeField] private GameObject ironPowder; // 철가루
    [SerializeField] private GameObject fluorescencePowder; // 형광가루
    [SerializeField] private ParticleSystem ironParticle; // 철가루 파티클
    [SerializeField] private ParticleSystem fluorescenceParticle; // 형광가루 파티클

    // [SerializeField] private GameObject soju_powder; // 소주병 파우더 묻혀야될 위치
    [SerializeField] private GameObject soju_fingerPrint; // 소주병에 남은 철가루 지문
    [SerializeField] GameObject originPos; // 원래 물체 존재했던 위치

    public bool isEquiped; // 이미 파우더 입혀진 경우
    public FingerPrintPowder.powderType p_type; // 파우더 타입

    // 철가루를 붓에 묻힐 경우
    private void IronPowder_equip()
    {
        ironPowder.SetActive(true);
        ironParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
        p_type = FingerPrintPowder.powderType.ironPowder;
    }

    // 형광가루를 붓에 묻힐 경우
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.SetActive(true);
        fluorescenceParticle.Play();
        SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
        p_type = FingerPrintPowder.powderType.fluorescencePowder;
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
            }
        }

        else // 가루 묻혀져있으면 방출
        {
            isEquiped = false;

            switch (p_type)
            {
                case FingerPrintPowder.powderType.ironPowder:
                    ironPowder.SetActive(false);
                    SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
                    ironParticle.Play();
                    break;
                case FingerPrintPowder.powderType.fluorescencePowder:
                    fluorescencePowder.SetActive(false);
                    SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BRUSH); // 사운드
                    fluorescenceParticle.Play();
                    break;
            }

            p_type = FingerPrintPowder.powderType.none;


            
        }



    }


    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos.transform.position;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
