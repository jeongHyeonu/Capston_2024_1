using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScreenTexture_VR_image : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.
    RenderTexture cameraPos;
    private int resWidth; //사진의 가로축 길이 
    private int resHeight; //사진의 새로축 길이
    string path; // 저장할 장소
    private static int pngNum = 1; //사진의 이름
    // Use this for initialization

    public Transform Parent; //사진의 부모
    public Transform Mirror; //사진을 저장할 프리팹
    public Transform MirrorPos; //사진을 저장할 장소
    public float Pos = -3f;

    //private bool first = false;
    public bool pull = false;
    public Vector3 firstPos; //사진의 저장소 처음 위치
    public Quaternion firstRot; //사진의 저장소 처음 각도



    //카메라 라이트 기능
    public GameObject camera_light;



    //0516 추가
    Texture2D screenShot;
    void Start()
    {
        resWidth = Screen.width;
        //resHeight = Screen.height;
        resHeight = Screen.width;// 0301자 변경사항 정사각형 이미지 저장을 위함
        path = Application.dataPath + "/ScreenShot/";
        //path = "jar:file://"+Application.dataPath + "/ScreenShot/";
        
        Debug.Log(path);

        //원래 카메라의 위치를 가져옴
        cameraPos = camera.targetTexture;
        firstPos = Parent.position + new Vector3(100f, 0f, 0f);
        firstRot = Parent.rotation;
        //Parent.position = Parent.position + new Vector3(100f, 0f, 0f);//0301자 추가 처음에 앨범의 위치를 멀리 보냄
        Debug.Log("처음 위치" + firstPos);
        Debug.Log("처음 각도" + firstRot);

        StartCoroutine(CheckCamera());//0308 코루틴 시작


        camera_light.SetActive(false);
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
        Debug.Log("cheakCam");
        //////
        while (true)
        {
            //////
            if (OVRInput.GetDown(OVRInput.Button.One) && GrabCamera.onCamera == true)
            {//카메라를 손에 쥐고 있고 A 버튼을 누를 경우 실행
                camera_light.SetActive(true);//라이트 키기
                SoundManager.Instance.PlaySFX(SoundManager.SFX_list.CAMERA);
                ClickScreenShot();
                Create3();
                camera_light.SetActive(false);//라이트 끄기
            }
            //yield return new WaitForSeconds(0); // _time 만큼 쉬었다가

            yield return null;

        }
        //StartCoroutine(CheckCamera()); // 재귀적으로 코루틴 실행
    }

    public void ClickScreenShot() //카메라에 나온 화면을 png 파일로 저장하는 코드
    {
        /*
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;*/
        //name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
       // name = path + pngNum.ToString() + ".png";//사진 이름
        pngNum++; // 1부터 1씩 증가하는 이름을 가지도록 저장
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();
        //screenShot이 Texture2D
        /*
        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);
        */
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
        if (Posx == -6f) // 가로로 3칸씩 저장하고 3칸이 저장시 1칸 아래에 저장
        {
            Posx = -9f;
            Posy = Posy - 1f;
            Parent.position = Parent.position + new Vector3(0, 1f, 0f);
        }
        Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(Posx, Posy, 0f), MirrorPos.rotation);//앨범을 복사하는 코드
        newMirror.SetParent(Parent);//앨범을 자식개체로 등록
        newMirror.localPosition = new Vector3(Posx, Posy, 0f);
        newMirror.localScale = Vector3.one;
        Posx = Posx + 1f;
        TextureChange textureChanger = newMirror.GetComponent<TextureChange>();
        //newMirror.TextureChange.ChangeTexture();
        textureChanger.ChangeTexture();//앨범에 이미지를 씌우는 코드
        textureChanger = null;

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
        Transform newMirror = Instantiate(Mirror, MirrorPos.position + new Vector3(105 + 145 * how_x, -85 + how_y * (-145), 0f), MirrorPos.rotation);
        newMirror.SetParent(Parent);
        newMirror.localPosition = new Vector3(105 + 145 * how_x, -85 + how_y * (-145), 0f);
        newMirror.localScale = Vector3.one;
        how_x++;



        //Image 가 아닌 것을 원한다면 TextureChange_image를 TextureChange로 변경
        TextureChange_image textureChanger = newMirror.GetComponent<TextureChange_image>();
        //newMirror.TextureChange.ChangeTexture();
        textureChanger.ChangeTexture(screenShot);
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
    public Transform canvas;//캔버스
    public void PullAlbum2()//앨범을 눈 앞으로 가져오는 코드
    {
        if (pull == false)
        {
            Debug.Log("가져오기");

            // Parent의 자식으로 a를 추가
            Parent.transform.SetParent(canvas);

            // a로부터 z축으로 3만큼 떨어진 곳으로 이동
            Parent.transform.localPosition = new Vector3(7.8f, 0.0f, 3f);
            Parent.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            pull = true;
        }
        else if (pull == true)
        {
            Debug.Log("보내기");

            // Parent와 a의 자식 관계를 해제
            Parent.transform.SetParent(null);

            // Parent를 처을 위치로
            Parent.position = firstPos;
            Parent.rotation = firstRot;

            Debug.Log("이동 위치" + Parent.position);
            Debug.Log("이동 각도" + Parent.rotation);
            pull = false;
        }
    }

   }
