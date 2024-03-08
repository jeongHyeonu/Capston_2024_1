using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture_VR : MonoBehaviour
{
    public Camera camera;       //�������� ī�޶�.
    RenderTexture cameraPos;
    private int resWidth; //������ ������ ���� 
    private int resHeight; //������ ������ ����
    string path; // ������ ���
    private static int pngNum = 1; //������ �̸�
    // Use this for initialization

    public Transform Parent; //������ �θ�
    public Transform Mirror; //������ ������ ������
    public Transform MirrorPos; //������ ������ ���
    public float Pos = -3f;

    //private bool first = false;
    public bool pull = false;
    public Vector3 firstPos; //������ ����� ó�� ��ġ
    public Quaternion firstRot; //������ ����� ó�� ����
    void Start()
    {
        resWidth = Screen.width;
        //resHeight = Screen.height;
        resHeight = Screen.width;// 0301�� ������� ���簢�� �̹��� ������ ����
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);

        //���� ī�޶��� ��ġ�� ������
        cameraPos = camera.targetTexture;
        firstPos = Parent.position + new Vector3(100f, 0f, 0f);
        firstRot = Parent.rotation;
        Parent.position = Parent.position + new Vector3(100f, 0f, 0f);//0301�� �߰� ó���� �ٹ��� ��ġ�� �ָ� ����
        Debug.Log("ó�� ��ġ" + firstPos);
        Debug.Log("ó�� ����" + firstRot);

        StartCoroutine(CheckCamera());//0308 �ڷ�ƾ ����
    }
    /*
    void Update()
    {


        if (OVRInput.GetDown(OVRInput.Button.One)&& pull == false&&GrabCamera.onCamera==true)
        {
            ClickScreenShot();
            Create2();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            PullAlbum2();
        }
    }*/


    IEnumerator CheckCamera()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && pull == false && GrabCamera.onCamera == true)
        {//ī�޶� �տ� ��� �ְ� A ��ư�� ���� ��� ����
            ClickScreenShot();
            Create2();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {//B ��ư�� ���� ��� ����
            PullAlbum2();
        }
        yield return new WaitForSeconds(0); // _time ��ŭ �����ٰ�
        StartCoroutine(CheckCamera()); // ��������� �ڷ�ƾ ����
    }

    public void ClickScreenShot() //ī�޶� ���� ȭ���� png ���Ϸ� �����ϴ� �ڵ�
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        //name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        name = path + pngNum.ToString() + ".png";//���� �̸�
        pngNum++; // 1���� 1�� �����ϴ� �̸��� �������� ����
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
        if (Posx == -6f) // ���η� 3ĭ�� �����ϰ� 3ĭ�� ����� 1ĭ �Ʒ��� ����
        {
            Posx = -9f;
            Posy = Posy - 1f;
            Parent.position = Parent.position + new Vector3(0, 1f, 0f);
        }
        Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Posx, Posy, 0f), MirrorPos.rotation);//�ٹ��� �����ϴ� �ڵ�
        newMirror.SetParent(Parent);//�ٹ��� �ڽİ�ü�� ���
        Posx = Posx + 1f;
        TextureChange textureChanger = newMirror.GetComponent<TextureChange>();
        //newMirror.TextureChange.ChangeTexture();
        textureChanger.ChangeTexture();//�ٹ��� �̹����� ����� �ڵ�
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
    public Transform eye;//center camera (�� ��)
    public void PullAlbum2()//�ٹ��� �� ������ �������� �ڵ�
    {
        if (pull == false)
        {
            Debug.Log("��������");

            // Parent�� �ڽ����� a�� �߰�
            Parent.transform.SetParent(eye);

            // a�κ��� z������ 3��ŭ ������ ������ �̵�
            Parent.position = eye.transform.position + new Vector3(7.8f, 0.5f, 3f);

            pull = true;
        }
        else if (pull == true)
        {
            Debug.Log("������");

            // Parent�� a�� �ڽ� ���踦 ����
            Parent.transform.SetParent(null);

            // Parent�� ó�� ��ġ��
            Parent.position = firstPos;
            Parent.rotation = firstRot;

            Debug.Log("�̵� ��ġ" + Parent.position);
            Debug.Log("�̵� ����" + Parent.rotation);
            pull = false;
        }
    }

   }
