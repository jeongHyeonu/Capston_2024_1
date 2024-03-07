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

    [SerializeField] private GameObject soju_powder; // 소주병 파우더 묻혀야될 위치
    [SerializeField] private GameObject soju_fingerPrint; // 소주병에 남은 철가루 지문

    public bool isEquiped; // 이미 파우더 입혀진 경우
    public FingerPrintPowder.powderType p_type; // 파우더 타입

    // 철가루를 붓에 묻힐 경우
    private void IronPowder_equip()
    {
        ironPowder.gameObject.SetActive(true);
        ironParticle.Play();
        p_type = FingerPrintPowder.powderType.ironPowder;
    }

    // 형광가루를 붓에 묻힐 경우
    private void FluorescencePowder_equip()
    {
        fluorescencePowder.gameObject.SetActive(true);
        fluorescenceParticle.Play();
        p_type = FingerPrintPowder.powderType.fluorescencePowder;
    }

    // 붓 상태에 따라 붓에 가루 장착 또는 붓에 묻혀진 가루 발사, 
    // 컨트롤러 Trigger 버튼 누르면 수행
    public void EquipOrEmitPowder()
    {
        if (!isEquiped) // 가루 안 묻혀져있으면 장착
        {
            // 소주병 가까이에 있고, 소주병에 파우더가 이미 묻혀진(active상태 = true) 경우 
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

        else // 가루 묻혀져있으면 발사
        {
            isEquiped = false;

            switch (p_type)
            {
                case FingerPrintPowder.powderType.ironPowder:
                    ironPowder.SetActive(false);
                    ironParticle.Play();
                    Debug.Log(Vector3.Distance(soju_powder.transform.position, this.transform.position));
                    // 발사한 위치 근처에 소주병이 있는 경우
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
