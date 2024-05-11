using TMPro;
using UnityEngine;

public class ChangeGloves : MonoBehaviour
{
    // ������ ���׸����� public���� �����Ͽ� �ν����Ϳ��� ������ �� �ֵ��� ��
    public Material newMaterial;

    // �浹 ��� ������Ʈ�� �ν����Ϳ��� ������ �� �ֵ��� ��
    public GameObject oculusHandObjectR;
    public GameObject oculusHandObjectL;
    // ������ ���׸����� ������ ����
    public Material originalMaterial;

    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI Score3;
    public TextMeshProUGUI Score4;

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
        //if (other.gameObject == oculusHandObject)
        if (other.gameObject.tag=="Hand")
        {
            Debug.Log("üũ123");
            // �� ���� Renderer ������Ʈ ��������
            Renderer handRenderer = oculusHandObjectR.GetComponent<Renderer>();

            Renderer handRenderer2 = oculusHandObjectL.GetComponent<Renderer>();
            if (handRenderer != null)
            {
                // ���ο� ���׸���� ����
                handRenderer.material = newMaterial;
                handRenderer2.material = newMaterial;
                Score1.text =""+ 10;
                Score2.text = "" + 10;
                Score3.text = "" + 10;
                Score4.text = "" + 10;
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

