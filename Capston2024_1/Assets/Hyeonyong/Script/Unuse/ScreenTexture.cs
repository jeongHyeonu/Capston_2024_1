using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture : MonoBehaviour
{
    public Camera camera;       //�������� ī�޶�.
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
        resHeight = Screen.width;// 0301�� ������� ���簢�� �̹��� ������ ����
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);

        //���� ī�޶��� ��ġ�� ������
        cameraPos = camera.targetTexture;

        Parent.position = Parent.position + new Vector3(100f, 0f, 0f);//0301�� �߰� ó���� �ٹ��� ��ġ�� �ָ� ����

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
        //Debug.Log("��Ĭ");
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

        //�ٽ� �⺻ ī�޶�� �ǵ���
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
    public void Create2() //0301�� �߰� �ٹ� ���� ��ġ
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


    public void PullAlbum() //0301�� �߰� �ٹ��� �ָ� ������ ��������
    {

        if (pull == false)
        {
            Debug.Log("��������");
            Parent.position = Parent.position + new Vector3(-100f, 0f, 0f);
            pull= true;
        }
        else if (pull == true)
        {
            Debug.Log("������");
            Parent.position = Parent.position + new Vector3(100f, 0f, 0f);
            pull = false;
        }

    }
}
