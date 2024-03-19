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

    //Setting UI Ȱ��
    public void SettingActive() 
    {
        SettingUIActive = true;
        SettingUI.SetActive(SettingUIActive);
    }

    //Setting UI ��Ȱ��
    public void SettingUnActive()
    {
        SettingUIActive = false;
        SettingUI.SetActive(SettingUIActive);
    }

   
    //Back ��ư �Լ�
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
