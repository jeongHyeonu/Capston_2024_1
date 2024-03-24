using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPaper : MonoBehaviour
{
    public Color newColor = Color.blue; // �� ������ �� ���� (���⼭�� �Ķ������� ����)

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ���̾ Liquid���� Ȯ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Liquid"))
        {
            Renderer renderer = GetComponent<Renderer>();

            // ������ ������Ʈ�� �����ϰ�, ���� ������ ������ ��쿡�� ���� ����
            if (renderer != null && renderer.material != null)
            {
                renderer.material.color = newColor; // ���ο� ������ ����
            }
        }
    }
}

