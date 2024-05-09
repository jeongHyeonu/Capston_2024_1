using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder_tutorial;

// 지문 검사 대상에 부여할 스크립트
// -----------------------------------------------
// 소주병 지문에 부여할 스크립트, 철가루 자석붓 올려놓을 경우 지문이 드러남
// 흉기 지문에 부여할 스크립트, 형광가루 자석붓 올려놓을 경우 지문이 드러남

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

    // 소주병 지문에 트리거 Enter시 또는 흉기 지문에 트리거 Enter시 실행
    private void OnTriggerEnter(Collider other)
    {
        // 지문 보이는 상태면, 테이프 닿았을때 지문 테이프 생성
        if (isVisible == true)
        {
            //급한대로 하드코딩.. ㅈㅅ
            if (this.object_type==ObjectType.cup && other.gameObject.name == "fingerprint_kit_01.tape")
            {
                GetComponent<MeshRenderer>().enabled = false;  
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush_tutorial brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush_tutorial>();
            if (brushObj.isStrong == true) return; // 분말 강도 너무 쌔면 실행 X

            if(brushObj.p_type == powderType.ironPowder && object_type == ObjectType.soju)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
                TutorialUX.Instance.SojuHologramOFF();
                tutoFourthBoard?.SetActive(true);
                flashLightGhostHand?.SetActive(true);
                rulerAndCard?.SetActive(true);
            }

            if (brushObj.p_type == powderType.fluorescencePowder && object_type == ObjectType.knife)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
                //TutorialUX.Instance.NextHologram();
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder && object_type == ObjectType.cup)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
                rulerAndCard?.SetActive(true);
            }
        }
    }
}
