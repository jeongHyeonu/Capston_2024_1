using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // ���� ������Ʈ
    public GameObject transparentObject;
    // ���� ������Ʈ
    public GameObject paperObject;
    // �ٸ��� ������Ʈ
    public GameObject ironObject;

    // ���̿� �ٸ��̰� ������ ����
    private bool ironOnPaper = false;
    // �ٸ��̰� ���� ������Ʈ�� ���� �ð�
    private float ironTouchTime = 0f;
    // �ٸ��̰� ���� ������Ʈ�� ��� �ִ� �ð� ����
    public float maxIronTouchTime = 5f;
    // ���� ������Ʈ�� �ʱ� ��
    private Color initialColor;

    void Start()
    {
        // ���� ������Ʈ�� �ʱ� ���� ����
        initialColor = transparentObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // �ٸ��̰� ���� ������Ʈ�� ��� �ִ� ���� �ð� ����
        if (ironOnPaper)
        {
            ironTouchTime += Time.deltaTime;
            // �ٸ��̰� ���� �ð� �̻� ��� ������ ���� ������Ʈ �ջ�
            if (ironTouchTime >= maxIronTouchTime)
            {
                DamageTransparentObject();
            }
        }
        else
        {
            // �ٸ��̰� ���� ������Ʈ�� ���� ���� ��� �ð� �ʱ�ȭ
            ironTouchTime = 0f;
        }
    }

    void DamageTransparentObject()
    {
        // ���� ������Ʈ �ջ� (��: ���� ����)
        transparentObject.GetComponent<Renderer>().material.color = Color.black;
        // ���⿡ �߰����� �ջ� ȿ���� ������ �� ����
    }

    // �浹�� ���۵Ǿ��� �� ȣ��
    void OnCollisionEnter(Collision collision)
    {
        // ���̿� �ٸ��̰� �浹���� ��
        if (collision.gameObject == paperObject && collision.gameObject == ironObject)
        {
            ironOnPaper = true;
        }
    }

    // �浹�� ������ �� ȣ��
    void OnCollisionExit(Collision collision)
    {
        // ���̿� �ٸ����� �浹�� ������ ��
        if (collision.gameObject == paperObject && collision.gameObject == ironObject)
        {
            ironOnPaper = false;
        }
    }
}

