using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture_VR_image_3 : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.
    RenderTexture cameraPos;
    private int resWidth; //사진의 가로축 길이 
    private int resHeight; //사진의 새로축 길이
    private static int pngNum = 1; //사진의 이름

    public Transform Parent; //사진의 부모
    public Transform MirrorPos; //사진을 저장할 장소
    public float Pos = -3f;

    public Vector3 firstPos; //사진의 저장소 처음 위치
    public Quaternion firstRot; //사진의 저장소 처음 각도

    //0516 추가
    Texture2D screenShot;


    //0521 앨범을 public으로 받아오기
    public GameObject[] newMirror;
    TextureChange_image textureChanger;

    RenderTexture rt;

    private int ImageNum = 0;

    public GameObject camera_Light;
    void Start()
    {
        //resWidth = Screen.width;
        //resHeight = Screen.width;// 0301자 변경사항 정사각형 이미지 저장을 위함

        //원래 카메라의 위치를 가져옴
        cameraPos = camera.targetTexture;

        resWidth = cameraPos.width;
        resHeight = cameraPos.width;

        firstPos = Parent.position + new Vector3(100f, 0f, 0f);
        firstRot = Parent.rotation;

        StartCoroutine(CheckCamera());//0308 코루틴 시작
    }


    IEnumerator CheckCamera()
    {
        while (true)
        {
            //////
            if (OVRInput.GetDown(OVRInput.Button.One) && GrabCamera.onCamera == true && ImageNum < 150)
            {//카메라를 손에 쥐고 있고 A 버튼을 누를 경우 실행
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

    public void ClickScreenShot() //카메라에 나온 화면을 png 파일로 저장하는 코드
    {
        //pngNum++; // 1부터 1씩 증가하는 이름을 가지도록 저장
        //rt = new RenderTexture(resWidth, resHeight, 24);
        //camera.targetTexture = rt;
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        //camera.Render();
        RenderTexture.active = camera.targetTexture;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        //다시 기본 카메라로 되돌림
        //camera.targetTexture = cameraPos;
        //camera.Render();
    }

    private int how_x = 0;
    private int how_y = 0;

    public void Create3()
    {
        Debug.Log("생성");
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

        //Image 가 아닌 것을 원한다면 TextureChange_image를 TextureChange로 변경
        textureChanger = newMirror[ImageNum].GetComponent<TextureChange_image>();
        textureChanger.ChangeTexture(screenShot);
        textureChanger = null;


        ImageNum++;
    }
}
