using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.
    RenderTexture cameraPos;
    private int resWidth;
    private int resHeight;
    string path;
    private static int pngNum = 1;
    // Use this for initialization

    public Transform Parent;
    public Transform Mirror;
    public Transform MirrorPos;
    public float Pos = -3f;

    //private bool first = false;

    public bool pull = false;

    void Start()
    {
        resWidth = Screen.width;
        //resHeight = Screen.height;
        resHeight = Screen.width;// 0301자 변경사항 정사각형 이미지 저장을 위함
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);

        //원래 카메라의 위치를 가져옴
        cameraPos = camera.targetTexture;

        Parent.position = Parent.position + new Vector3(100f, 0f, 0f);//0301자 추가 처음에 앨범의 위치를 멀리 보냄

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C)&&pull==false)
        {
            ClickScreenShot();
            Create2();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PullAlbum();
        }
    }


    public void ClickScreenShot()
    {
        //Debug.Log(resWidth);
        //Debug.Log(resHeight);
        //Debug.Log("찰칵");
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

    public void Create()
    {
            Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Pos, 0f, 0f), MirrorPos.rotation);
            newMirror.SetParent(Parent);
            Pos = Pos - 3f;
        TextureChange textureChanger = newMirror.GetComponent<TextureChange>();
        //newMirror.TextureChange.ChangeTexture();
        textureChanger.ChangeTexture();
        textureChanger = null;
    }

    public float Posx = -9f;
    public float Posy = 0f;
    public void Create2() //0301자 추가 앨범 생성 배치
    {
        if (Posx == 0f)
        {
            Posx = -9f;
            Posy = Posy - 3f;
            Parent.position = Parent.position + new Vector3(0, 3f, 0f);
        }
        Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Posx, Posy, 0f), MirrorPos.rotation);
        newMirror.SetParent(Parent);
        Posx = Posx + 3f;
        TextureChange textureChanger = newMirror.GetComponent<TextureChange>();
        //newMirror.TextureChange.ChangeTexture();
        textureChanger.ChangeTexture();
        textureChanger = null;

    }


    public void PullAlbum() //0301자 추가 앨범을 멀리 보내고 가져오기
    {

        if (pull == false)
        {
            Debug.Log("가져오기");
            Parent.position = Parent.position + new Vector3(-100f, 0f, 0f);
            pull= true;
        }
        else if (pull == true)
        {
            Debug.Log("보내기");
            Parent.position = Parent.position + new Vector3(100f, 0f, 0f);
            pull = false;
        }

    }
}
