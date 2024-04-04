using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.
    RenderTexture cameraPos;
    private int resWidth;
    private int resHeight;
    string path;
    private static int pngNum = 1;
    // Use this for initialization
    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);

        //원래 카메라의 위치를 가져옴
        cameraPos = camera.targetTexture;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C)) 
            { ClickScreenShot();
        }
    }
    public void ClickScreenShot()
    {
        Debug.Log("찰칵");
        Debug.Log(resWidth);
        Debug.Log(resHeight);
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        //name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        name = path + pngNum.ToString() + ".png";
        pngNum++;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);

        //다시 기본 카메라로 되돌림
        camera.targetTexture = cameraPos;
        camera.Render();
        // RenderTexture.active = null;
    }
}