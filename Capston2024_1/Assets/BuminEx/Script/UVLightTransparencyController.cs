using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLightTransparencyController : MonoBehaviour
{
    public LayerMask uvLightLayer; // UV_Light 레이어를 가진 오브젝트를 가리키는 레이어 마스크
    public float maxTransparency = 0.5f; // 최대 투명도

    private Renderer objectRenderer; // 오브젝트 렌더러 컴포넌트 참조

    void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // 렌더러 컴포넌트 참조
    }

    void Update()
    {
        // 레이캐스트를 통해 UV_Light 레이어를 가진 오브젝트를 검출
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, uvLightLayer))
        {
            // 검출된 오브젝트의 머터리얼 가져오기
            Material objectMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;

            // 투명도를 설정할 경우 해당 오브젝트가 레이캐스트한 거리에 따라 투명도를 조절할 수 있음
            float distance = Vector3.Distance(transform.position, hit.point);

            // 투명도 계산
            float transparency = Mathf.Clamp(distance / maxTransparency, 0f, 1f);

            // 오브젝트의 투명도 설정
            objectMaterial.SetFloat("_Alpha", transparency); // "_Alpha"는 머터리얼의 투명도를 조절하는 프로퍼티 이름에 따라 변경될 수 있음
        }
    }
}
