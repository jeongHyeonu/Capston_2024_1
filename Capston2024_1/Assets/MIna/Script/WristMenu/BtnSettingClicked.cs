using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnSettingClicked : MonoBehaviour
{
    //SettingUI ��ü
    public GameObject SettingUI;
    public Button backBtn;
    public Button restartBtn;
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

    //ReStart ��ư �Լ�
    /*
    public void GoToStartScene()
    {
        SceneManager.LoadScene("Lab_Mina");
    }*/


    public GameObject CenterEyeObj;  // ��ŧ���� CameraRig�� CenterEyeObj ����
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("�� �̵� ����");
        OFade = CenterEyeObj.transform.GetComponent<OVRScreenFade>();
        StartCoroutine(SceneFadeCoroutine());
    }
    IEnumerator SceneFadeCoroutine()
    {
        OFade.FadeOut();

        yield return new WaitForSeconds(OFade.fadeTime);

        SceneManager.LoadScene("Opening");
    }


    private void Start()
    {
        SettingUnActive();  //SettingUI UnActvie
    }

    void Update()
    {
        backBtn.onClick.AddListener(BackBtnOnClick);    //SettingUI UnActvie
        restartBtn.onClick.AddListener(SceneFade);
    }
}
