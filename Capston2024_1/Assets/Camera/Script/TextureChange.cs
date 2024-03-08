using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// ��ũ�������� ����� �̹����� �ҷ����� �ڵ��̴�. ���� 1~ �ִ� ������ �ִ� �͸� �ҷ������� �ۼ�
public class TextureChange : MonoBehaviour
{
    private string texturePath = "Assets/ScreenShot/"; // ���� ���
    private static int index = 1; //���� �̸�

    void Update()
    {
        // C Ű�� ������ �� �ؽ�ó�� �����մϴ�.
        //if (Input.GetKeyDown(KeyCode.C))
        //{
           // ChangeTexture();
        //}
    }

    public void ChangeTexture()
    {
        //Debug.Log(index.ToString());

        string fileName = index.ToString() + ".png"; // ���� �̸� ����
        byte[] fileData = File.ReadAllBytes(Path.Combine(texturePath, fileName));
        //���� ���� �̸��� ���� ������ �ҷ���

        // Texture2D�� �����ϰ� �о�� �̹����� ����
        Texture2D textureToApply = new Texture2D(2, 2);
        textureToApply.LoadImage(fileData);

        // Renderer ������Ʈ�� ������
        Renderer rend = GetComponent<Renderer>();

        // Renderer�� �ؽ��ĸ� ��ũ�������� ����
        rend.material.mainTexture = textureToApply;

        index++;

        //���� ����
        transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
