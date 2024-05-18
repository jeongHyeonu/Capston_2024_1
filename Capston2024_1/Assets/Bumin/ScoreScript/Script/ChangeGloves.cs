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
    public TextMeshProUGUI Score5;


    public GameObject EVi1;
    public GameObject EVi2;
    public GameObject EVi3;
    public GameObject EVi4;
    public bool onLab = false;
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
                Score1.text = "" + 5;
                Score2.text = "" + 5;
                Score3.text = "" + 5;
                Score4.text = "" + 5;
                if (onLab == false)
                {
                    Score5.text = "" + 5;
                }
                SoundManager.Instance.PlaySFX(SoundManager.SFX_list.PUT_ON_1);

                if (onLab == true)
                {
                    Debug.Log("�����̴�.");
                    if (EVi1.activeSelf == false)
                    {
                        Score1.text = "" + 0;
                    }
                    if (EVi2.activeSelf == false)
                    {
                        Score2.text = "" + 0;
                    }
                    if (EVi3.activeSelf == false)
                    {
                        Score3.text = "" + 0;
                    }
                    if (EVi4.activeSelf == false)
                    {
                        Score4.text = "" + 0;
                    }
                }

            }
        }
    }

    /*
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
                if (onLab == true)
                {
                    Debug.Log("�����̴�.");
                    if (EVi1.activeSelf == false)
                    {
                        Score1.text = "" + 0;
                    }
                    if (EVi2.activeSelf == false)
                    {
                        Score2.text = "" + 0;
                    }
                    if (EVi3.activeSelf == false)
                    {
                        Score3.text = "" + 0;
                    }
                    if (EVi4.activeSelf == false)
                    {
                        Score4.text = "" + 0;
                    }
                }
        }
    }
    */
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

