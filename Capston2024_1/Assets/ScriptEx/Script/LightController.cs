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
        // �ʱ⿡ ����Ʈ�� ������Ʈ�� ���Ӵϴ�.
        targetLight.enabled = isLightOn;
        targetObject.SetActive(isObjectActive);
    }

    private void Update()
    {
        // ��ŧ�������� X ��ư�� ���ȴ��� Ȯ��
        if (Input.GetButtonDown("XButton"))
        {
            ToggleLightAndObject();
        }
    }

    public void ToggleLightAndObject()
    {
        // ����Ʈ ���� ����
        isLightOn = !isLightOn;
        targetLight.enabled = isLightOn;

        // ������Ʈ ���� ����
        isObjectActive = !isObjectActive;
        targetObject.SetActive(isObjectActive);
    }
}



