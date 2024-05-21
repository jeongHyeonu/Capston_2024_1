using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture_VR_image_3 : MonoBehaviour
{
    public Camera camera;       //�������� ī�޶�.
    RenderTexture cameraPos;
    private int resWidth; //������ ������ ���� 
    private int resHeight; //������ ������ ����
    private static int pngNum = 1; //������ �̸�

    public Transform Parent; //������ �θ�
    public Transform MirrorPos; //������ ������ ���
    public float Pos = -3f;

    public Vector3 firstPos; //������ ����� ó�� ��ġ
    public Quaternion firstRot; //������ ����� ó�� ����

    //0516 �߰�
    Texture2D screenShot;


    //0521 �ٹ��� public���� �޾ƿ���
    public GameObject[] newMirror;
    TextureChange_image textureChanger;

    RenderTexture rt;

    private int ImageNum = 0;

    public GameObject camera_Light;
    void Start()
    {
        //resWidth = Screen.width;
        //resHeight = Screen.width;// 0301�� ������� ���簢�� �̹��� ������ ����

        //���� ī�޶��� ��ġ�� ������
        cameraPos = camera.targetTexture;

        resWidth = cameraPos.width;
        resHeight = cameraPos.width;

        firstPos = Parent.position + new Vector3(100f, 0f, 0f);
        firstRot = Parent.rotation;

        StartCoroutine(CheckCamera());//0308 �ڷ�ƾ ����
    }


    IEnumerator CheckCamera()
    {
        while (true)
        {
            //////
            if (OVRInput.GetDown(OVRInput.Button.One) && GrabCamera.onCamera == true && ImageNum < 150)
            {//ī�޶� �տ� ��� �ְ� A ��ư�� ���� ��� ����
                SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);

                if (camera_Light != null)
                {
                    camera_Light.SetActive(true);
                }
                ClickScreenShot();
                Create3();

                if (camera_Light != null)
                {
                    camera_Light.SetActive(false);
                }

            }

            yield return null;

        }
    }

    public void ClickScreenShot() //ī�޶� ���� ȭ���� png ���Ϸ� �����ϴ� �ڵ�
    {
        //pngNum++; // 1���� 1�� �����ϴ� �̸��� �������� ����
        //rt = new RenderTexture(resWidth, resHeight, 24);
        //camera.targetTexture = rt;
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        //camera.Render();
        RenderTexture.active = camera.targetTexture;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        //�ٽ� �⺻ ī�޶�� �ǵ���
        //camera.targetTexture = cameraPos;
        //camera.Render();
    }

    private int how_x = 0;
    private int how_y = 0;

    public void Create3()
    {
        Debug.Log("����");
        if (how_x >= 3)
        {
            how_x = 0;
            how_y++;
        }

        newMirror[ImageNum].transform.position = MirrorPos.position + new Vector3(105 + 145 * how_x, -85 + how_y * (-145), 0f);
        newMirror[ImageNum].transform.rotation = MirrorPos.rotation;
        newMirror[ImageNum].transform.SetParent(Parent);
        newMirror[ImageNum].transform.localPosition = new Vector3(105 + 145 * how_x, -85 + how_y * (-145), 0f);
        newMirror[ImageNum].transform.localScale = Vector3.one;
        how_x++;

        //Image �� �ƴ� ���� ���Ѵٸ� TextureChange_image�� TextureChange�� ����
        textureChanger = newMirror[ImageNum].GetComponent<TextureChange_image>();
        textureChanger.ChangeTexture(screenShot);
        textureChanger = null;


        ImageNum++;
    }
}
