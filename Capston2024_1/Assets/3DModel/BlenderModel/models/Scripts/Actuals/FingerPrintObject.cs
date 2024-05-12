using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FingerPrintPowder;

// 지문 검사 대상에 부여할 스크립트
public class FingerPrintObject : MonoBehaviour
{
    public enum ObjectType
    {
        iron,
        flour,
        redFlour,
        none,
    }

    public bool isVisible = false;
    public ObjectType obj_type = ObjectType.none; // 붓으로 문지른게 어떤 색인지 체크

    [SerializeField] powderType answerPowder;
    [SerializeField] TextMeshProUGUI targetScore1;
    [SerializeField] TextMeshProUGUI targetScore2;
    [SerializeField] GameObject rulerAndCard;
    [SerializeField] Material[] mat = new Material[3];

    // 소주병 지문에 트리거 Enter시 또는 흉기 지문에 트리거 Enter시 실행
    private void OnTriggerEnter(Collider other)
    {

        // 지문 안 보이는 상태라면, 붓으로 물체 문지르면 지문 드러남
        if (isVisible==false && other.gameObject.name == "brushHead")
        {
            FingerPrintBrush brushObj = other.transform.parent.gameObject.GetComponent<FingerPrintBrush>();

            // 점수1, 적절한 양의 분말을 묻혔는가?
            if (!brushObj.isStrong) targetScore1.text = "15";

            // 점수2, 알맞은 색 분말을 묻혔는가?
            if (brushObj.p_type == answerPowder) targetScore2.text = "15";

            if (brushObj.p_type == powderType.ironPowder) // 철가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.iron;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
            }

            if (brushObj.p_type == powderType.fluorescencePowder) // 형광가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.flour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
            }

            if (brushObj.p_type == powderType.fluorescenceRedPowder) // 적색가루 묻혔으면, 매터리얼 변경
            {
                obj_type = ObjectType.redFlour;
                this.gameObject.GetComponent<MeshRenderer>().material = mat[2];
            }

            // 지문 보이게끔
            this.gameObject.GetComponent<MeshRenderer>().material.DOFade(1f, 2f);
            isVisible = true; // 나중에 테이프로 채취시, 지문이 드러났는지 여부가 true일때 채취 가능
            rulerAndCard?.SetActive(true); // 지문 보이면 자/카드 등장

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_3); // 사운드
        }
    }
}
