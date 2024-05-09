using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light targetLight;
    public GameObject targetObject;

    private bool isLightOn = false;
    private bool isObjectActive = false;

    private void Start()
    {
        // 초기에 라이트와 오브젝트를 꺼둡니다.
        targetLight.enabled = isLightOn;
        targetObject.SetActive(isObjectActive);
    }

    private void Update()
    {
        // 오큘러스에서 X 버튼이 눌렸는지 확인
        if (Input.GetButtonDown("XButton"))
        {
            ToggleLightAndObject();
        }
    }

    public void ToggleLightAndObject()
    {
        // 라이트 상태 변경
        isLightOn = !isLightOn;
        targetLight.enabled = isLightOn;

        // 오브젝트 상태 변경
        isObjectActive = !isObjectActive;
        targetObject.SetActive(isObjectActive);
    }
}



