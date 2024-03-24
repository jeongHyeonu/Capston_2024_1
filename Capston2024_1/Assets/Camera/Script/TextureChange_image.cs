using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

// ��ũ�������� ����� �̹����� �ҷ����� �ڵ��̴�. ���� 1~ �ִ� ������ �ִ� �͸� �ҷ������� �ۼ�
public class TextureChange_image : MonoBehaviour
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


        Sprite sprite = Sprite.Create(textureToApply, new Rect(0, 0, textureToApply.width, textureToApply.height),
            new Vector2(0.5f, 0.5f));
        Image s_rend = GetComponent<Image>();
        s_rend.sprite= sprite;

        index++;
    }
}
