using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FingerPrintPowder;

// 소주병 지문에 부여할 스크립트, 철가루 자석붓 올려놓을 경우 지문이 드러남
public class FingerPrintSoju : MonoBehaviour
{
    public bool isVisible = false;

    // 소주병 지문에 트리거 Enter시 실행
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            if(brushObj.p_type == powderType.ironPowder)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
                isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
            }
        }
    }
}
