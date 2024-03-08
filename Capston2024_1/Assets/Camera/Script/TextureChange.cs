using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 스크린샷으로 저장된 이미지를 불러오는 코드이다. 현재 1~ 있는 값까지 있는 것만 불러오도록 작성
public class TextureChange : MonoBehaviour
{
    private string texturePath = "Assets/ScreenShot/"; // 저장 경로
    private static int index = 1; //파일 이름

    void Update()
    {
        // C 키를 눌렀을 때 텍스처를 변경합니다.
        //if (Input.GetKeyDown(KeyCode.C))
        //{
           // ChangeTexture();
        //}
    }

    public void ChangeTexture()
    {
        //Debug.Log(index.ToString());

        string fileName = index.ToString() + ".png"; // 파일 이름 생성
        byte[] fileData = File.ReadAllBytes(Path.Combine(texturePath, fileName));
        //위의 파일 이름을 가진 파일을 불러옴

        // Texture2D를 생성하고 읽어온 이미지를 적용
        Texture2D textureToApply = new Texture2D(2, 2);
        textureToApply.LoadImage(fileData);

        // Renderer 컴포넌트를 가져옴
        Renderer rend = GetComponent<Renderer>();

        // Renderer의 텍스쳐를 스크린샷으로 변경
        rend.material.mainTexture = textureToApply;

        index++;

        //각도 조절
        transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
