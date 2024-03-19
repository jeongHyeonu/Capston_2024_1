using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSettingClicked : MonoBehaviour
{

    public GameObject SettingUI;
    public Button backBtn;
    //public GameObject SettingUIAnchor;

    public static bool SettingUIActive;

    public int clickCount = 0;

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
        SettingUnActive();
    }

    void Update()
    {
        backBtn.onClick.AddListener(BackBtnOnClick);
    }
}
