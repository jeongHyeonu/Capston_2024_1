using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSettingClicked : MonoBehaviour
{
    //SettingUI 객체
    public GameObject SettingUI;
    public Button backBtn;
    //public GameObject SettingUIAnchor;

    public static bool SettingUIActive; //SettingUI 활성 상태 유무

    //Setting UI 활성
    public void SettingActive() 
    {
        SettingUIActive = true;
        SettingUI.SetActive(SettingUIActive);
    }

    //Setting UI 비활성
    public void SettingUnActive()
    {
        SettingUIActive = false;
        SettingUI.SetActive(SettingUIActive);
    }

   
    //Back 버튼 함수
    public void BackBtnOnClick()
    {
        SettingUnActive();
    }


    private void Start()
    {
        SettingUnActive();  //SettingUI UnActvie
    }

    void Update()
    {
        backBtn.onClick.AddListener(BackBtnOnClick);    //SettingUI UnActvie
    }
}
