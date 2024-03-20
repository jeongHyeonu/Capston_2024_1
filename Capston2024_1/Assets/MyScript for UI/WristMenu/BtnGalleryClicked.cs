using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGalleryClicked : MonoBehaviour
{
    public GameObject GalleryUI;
    public Button backBtn;
    //public GameObject GalleryUIAnchor;
    public static bool GalleryUIActive;     //GalleryUI Ȱ�� ���� ����

    //Setting UI Ȱ��
    public void GalleryActive()
    {
        GalleryUIActive = true;
        GalleryUI.SetActive(GalleryUIActive);
        WristMenuVR.WristMenuUIActive = false;
    }

    //Setting UI ��Ȱ��
    public void GalleryUnActive()
    {
        GalleryUIActive = false;
        GalleryUI.SetActive(GalleryUIActive);
    }


    //Back ��ư �Լ�
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
