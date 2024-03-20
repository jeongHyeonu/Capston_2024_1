using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGalleryClicked : MonoBehaviour
{
    public GameObject GalleryUI;
    public Button backBtn;
    //public GameObject GalleryUIAnchor;
    public static bool GalleryUIActive;     //GalleryUI 활성 상태 유무

    //Setting UI 활성
    public void GalleryActive()
    {
        GalleryUIActive = true;
        GalleryUI.SetActive(GalleryUIActive);
        WristMenuVR.WristMenuUIActive = false;
    }

    //Setting UI 비활성
    public void GalleryUnActive()
    {
        GalleryUIActive = false;
        GalleryUI.SetActive(GalleryUIActive);
    }


    //Back 버튼 함수
    public void BackBtnOnClick()
    {
        GalleryUnActive();
    }


    private void Start()
    {
        GalleryUnActive();  //GalleryUI Actvie
    }

    void Update()
    {
        backBtn.onClick.AddListener(BackBtnOnClick);    //GalleryUI unActvie
    }
}
