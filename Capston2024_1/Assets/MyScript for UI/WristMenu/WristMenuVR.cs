using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristMenuVR : MonoBehaviour
{
    //�ո� �޴� ����
    public GameObject WristMenu;
    public GameObject WristMenuAnchor;
    public static bool WristMenuUIActive;

    // �ո�UI Ȱ��ȭ
    public void WristMenuActive()
    {
        WristMenuUIActive = true;
        WristMenu.SetActive(WristMenuUIActive);
    }

    // �ո�UI ��Ȱ��ȭ
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
        //��Ʈ�ѷ� X��ư ������ WristUI Ȱ��/��Ȱ��
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            WristMenuUIActive = !WristMenuUIActive;
            WristMenu.SetActive(WristMenuUIActive);
        }
        //WristUI�� Ȱ��ȭ ������ ���
        if (WristMenuUIActive)
        {
            WristMenu.transform.position = WristMenuAnchor.transform.position;
            WristMenu.transform.eulerAngles = new Vector3(WristMenuAnchor.transform.eulerAngles.x + 15, WristMenuAnchor.transform.eulerAngles.y, 0);

        }

        //SettingUI,GalleryUI�� Ȱ��ȭ ������ ��� -> WristUI ����
        if(BtnSettingClicked.SettingUIActive == true || BtnGalleryClicked.GalleryUIActive == true)
        {
            WristMenuUIActive = false;
            WristMenu.SetActive(WristMenuUIActive);
        }

    }
}
