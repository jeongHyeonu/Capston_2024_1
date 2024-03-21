using UnityEngine;

public class FlashlightAndTransparentObjectController : MonoBehaviour
{
    // 손전등 광원
    public Light flashlight;
    // 투명 오브젝트의 태그
    public string transparentObjectTag = "TransparentObject";
    // 투명 오브젝트와 광원 사이의 거리
    public float distanceThreshold = 5f;
    // 오큘러스 컨트롤러의 버튼
    public OVRInput.Button toggleButton = OVRInput.Button.One;

    void Start()
    {
        // 오큘러스 컨트롤러의 버튼 입력 확인
        if (OVRInput.GetDown(toggleButton))
        {
            // 광원을 켜거나 끔
            flashlight.enabled = !flashlight.enabled;
        }
    }

    void Update()
    {
        // 손전등 광원이 켜져있을 때만 투명 오브젝트를 처리
        if (flashlight.enabled)
        {
            // 광원과 투명 오브젝트 사이의 거리 계산
            GameObject[] transparentObjects = GameObject.FindGameObjectsWithTag(transparentObjectTag);

            foreach (GameObject transparentObject in transparentObjects)
            {
                float distanceToFlashlight = Vector3.Distance(transparentObject.transform.position, flashlight.transform.position);

                // 거리가 일정 거리 이하인 경우 오브젝트를 활성화
                if (distanceToFlashlight <= distanceThreshold)
                {
                    transparentObject.SetActive(true);
                }
                else
                {
                    // 일정 거리 이상인 경우 오브젝트를 비활성화
                    transparentObject.SetActive(false);
                }
            }
        }
    }
}

