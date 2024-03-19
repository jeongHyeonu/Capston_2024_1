using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristMenuVR : MonoBehaviour
{
    //손목 메뉴 관련
    public GameObject WristMenu;
    public GameObject WristMenuAnchor;
    public static bool WristMenuUIActive;

    // 손목UI 활성화
    public void WristMenuActive()
    {
        WristMenuUIActive = true;
        WristMenu.SetActive(WristMenuUIActive);
    }

    // 손목UI 비활성화
    public void WristMenuUnActive()
    {
        WristMenuUIActive = false;
        WristMenu.SetActive(WristMenuUIActive);
    }

    private void Start()
    {
        WristMenuUnActive();
    }

    private void Update()
    {
        //컨트롤러 X버튼 누르면 WristUI 활성/비활성
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            WristMenuUIActive = !WristMenuUIActive;
            WristMenu.SetActive(WristMenuUIActive);
        }
        //WristUI가 활성화 상태일 경우
        if (WristMenuUIActive)
        {
            WristMenu.transform.position = WristMenuAnchor.transform.position;
            WristMenu.transform.eulerAngles = new Vector3(WristMenuAnchor.transform.eulerAngles.x + 15, WristMenuAnchor.transform.eulerAngles.y, 0);

        }

        //SettingUI,GalleryUI가 활성화 상태인 경우 -> WristUI 끄기
        if(BtnSettingClicked.SettingUIActive == true || BtnGalleryClicked.GalleryUIActive == true)
        {
            WristMenuUIActive = false;
            WristMenu.SetActive(WristMenuUIActive);
        }

    }
}
