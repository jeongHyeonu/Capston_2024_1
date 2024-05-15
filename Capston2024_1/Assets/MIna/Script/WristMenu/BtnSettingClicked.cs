using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnSettingClicked : MonoBehaviour
{
    //SettingUI 객체
    public GameObject SettingUI;
    public Button backBtn;
    public Button restartBtn;
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

    //ReStart 버튼 함수
    /*
    public void GoToStartScene()
    {
        SceneManager.LoadScene("Lab_Mina");
    }*/


    public GameObject CenterEyeObj;  // 오큘러스 CameraRig의 CenterEyeObj 연결
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("씬 이동 시작");
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
