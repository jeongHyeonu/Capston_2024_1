using TMPro;
using UnityEngine;

public class ChangeGloves : MonoBehaviour
{
    // 변경할 메테리얼을 public으로 선언하여 인스펙터에서 설정할 수 있도록 함
    public Material newMaterial;

    // 충돌 대상 오브젝트를 인스펙터에서 설정할 수 있도록 함
    public GameObject oculusHandObjectR;
    public GameObject oculusHandObjectL;
    // 원래의 메테리얼을 저장할 변수
    public Material originalMaterial;

    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI Score3;
    public TextMeshProUGUI Score4;
    public TextMeshProUGUI Score5;

    private void Start()
    {
        // 시작할 때 원래의 메테리얼을 저장
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 충돌한 것이 설정된 오브젝트와 일치하면
        //if (other.gameObject == oculusHandObject)
        if (other.gameObject.tag=="Hand")
        {
            Debug.Log("체크123");
            // 손 모델의 Renderer 컴포넌트 가져오기
            Renderer handRenderer = oculusHandObjectR.GetComponent<Renderer>();

            Renderer handRenderer2 = oculusHandObjectL.GetComponent<Renderer>();
            if (handRenderer != null)
            {
                // 새로운 메테리얼로 변경
                handRenderer.material = newMaterial;
                handRenderer2.material = newMaterial;
                Score1.text =""+ 5;
                Score2.text = "" + 5;
                Score3.text = "" + 5;
                Score4.text = "" + 5;
                Score5.text = "" + 5;
                SoundManager.Instance.PlaySFX(SoundManager.SFX_list.PUT_ON_1);
            }
        }
    }

    private void OnDestroy()
    {
        // 스크립트가 파괴될 때, 씬이 끝날 때 원래의 메테리얼로 복구
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = originalMaterial;
        }
    }
}

