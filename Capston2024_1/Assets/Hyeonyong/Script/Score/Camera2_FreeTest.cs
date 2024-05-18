using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2_FreeTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Door;
    public GameObject DoorCheck;
    public bool checkDoor=false;

    public GameObject Chair;
    public GameObject ChairCheck;
    public bool checkChair=false;

    public GameObject Desk;
    public GameObject DeskCheck;
    public bool checkDesk = false;

    public GameObject Drawer;
    public GameObject DrawerCheck;
    public bool checkDrawer = false;

    public GameObject WaterTap;
    public GameObject WaterTapCheck;
    public bool checkWaterTap = false;

    //2개 더 추가 예정


    public GameObject HandTrigger;
    npcText failed;




    void Start()
    {
        Debug.Log(gameObject.name);
        failed = HandTrigger.GetComponent<npcText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Door.activeSelf == false)
        {
                if (DoorCheck.activeSelf == true && checkDoor == false)
               { 
                Debug.Log("문 경고메시지 출력");
                checkDoor = true;
                failed.FailedSecondCamera();
               }     
        }

        if (Chair.activeSelf == false)
        {
            if (ChairCheck.activeSelf == true && checkChair == false)
            {
                Debug.Log("의자 경고메시지 출력");
                checkChair = true;
                failed.FailedSecondCamera();
            }
        }

        if (Desk.activeSelf == false)
        {
            if (DeskCheck.activeSelf == true && checkDesk == false)
            {
                Debug.Log("탁자 경고메시지 출력");
                checkDesk = true;
                failed.FailedSecondCamera();
            }
        }


        if (Drawer.activeSelf == false)
        {
            if (DrawerCheck.activeSelf == true && checkDrawer == false)
            {
                Debug.Log("서랍장 경고메시지 출력");
                checkDrawer = true;
                failed.FailedSecondCamera();
            }
        }

        if (WaterTap.activeSelf == false)
        {
            if (WaterTapCheck.activeSelf == true && checkWaterTap == false)
            {
                Debug.Log("수도꼭지 경고메시지 출력");
                checkWaterTap = true;
                failed.FailedSecondCamera();
            }
        }



    }
}
