using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVLightTransparencyController : MonoBehaviour
{
    public LayerMask uvLightLayer; // UV_Light ���̾ ���� ������Ʈ�� ����Ű�� ���̾� ����ũ
    public float maxTransparency = 0.5f; // �ִ� ����

    private Renderer objectRenderer; // ������Ʈ ������ ������Ʈ ����

    void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // ������ ������Ʈ ����
    }

    void Update()
    {
        // ����ĳ��Ʈ�� ���� UV_Light ���̾ ���� ������Ʈ�� ����
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, uvLightLayer))
        {
            // ����� ������Ʈ�� ���͸��� ��������
            Material objectMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;

            // ������ ������ ��� �ش� ������Ʈ�� ����ĳ��Ʈ�� �Ÿ��� ���� ������ ������ �� ����
            float distance = Vector3.Distance(transform.position, hit.point);

            // ���� ���
            float transparency = Mathf.Clamp(distance / maxTransparency, 0f, 1f);

            // ������Ʈ�� ���� ����
            objectMaterial.SetFloat("_Alpha", transparency); // "_Alpha"�� ���͸����� ������ �����ϴ� ������Ƽ �̸��� ���� ����� �� ����
        }
    }
}
