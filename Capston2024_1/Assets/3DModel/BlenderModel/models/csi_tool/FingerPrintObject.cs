using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder;

// 지문 검사 대상에 부여할 스크립트
// -----------------------------------------------
// 소주병 지문에 부여할 스크립트, 철가루 자석붓 올려놓을 경우 지문이 드러남
// 흉기 지문에 부여할 스크립트, 형광가루 자석붓 올려놓을 경우 지문이 드러남

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

    // 소주병 지문에 트리거 Enter시 또는 흉기 지문에 트리거 Enter시 실행
    private void OnTriggerEnter(Collider other)
    {
        if (isVisible == true) return; // 지문 보이는 상태면 실행X

        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            if(brushObj.p_type == powderType.ironPowder && object_type == ObjectType.soju)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
                tutoCam?.secondStep_ON();
                TutorialUX.Instance.SojuHologramOFF();
                tutoFourthBoard?.SetActive(true);
            }

            if (brushObj.p_type == powderType.fluorescencePowder && object_type == ObjectType.knife)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
                //TutorialUX.Instance.NextHologram();
            }
        }
    }
}
