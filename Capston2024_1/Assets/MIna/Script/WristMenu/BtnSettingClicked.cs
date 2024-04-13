using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSettingClicked : MonoBehaviour
{
    //SettingUI ��ü
    public GameObject SettingUI;
    public Button backBtn;
    //public GameObject SettingUIAnchor;

    public static bool SettingUIActive; //SettingUI Ȱ�� ���� ����

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
        SettingUnActive();  //SettingUI UnActvie
    }

    void Update()
    {
        backBtn.onClick.AddListener(BackBtnOnClick);    //SettingUI UnActvie
    }
}
