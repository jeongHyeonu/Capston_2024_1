using UnityEngine;

public class ChangeGloves : MonoBehaviour
{
    // ������ ���׸����� public���� �����Ͽ� �ν����Ϳ��� ������ �� �ֵ��� ��
    public Material newMaterial;

    // �浹 ��� ������Ʈ�� �ν����Ϳ��� ������ �� �ֵ��� ��
    public GameObject oculusHandObject;

    // ������ ���׸����� ������ ����
    private Material originalMaterial;

    private void Start()
    {
        // ������ �� ������ ���׸����� ����
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� �浹�� ���� ������ ������Ʈ�� ��ġ�ϸ�
        if (other.gameObject == oculusHandObject)
        {
            // �� ���� Renderer ������Ʈ ��������
            Renderer handRenderer = other.GetComponent<Renderer>();
            if (handRenderer != null)
            {
                // ���ο� ���׸���� ����
                handRenderer.material = newMaterial;
            }
        }
    }

    private void OnDestroy()
    {
        // ��ũ��Ʈ�� �ı��� ��, ���� ���� �� ������ ���׸���� ����
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = originalMaterial;
        }
    }
}

