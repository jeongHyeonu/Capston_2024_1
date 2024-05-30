using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2_FreeTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Door;
    public GameObject DoorCheck;
    public bool checkDoor=false;
    public bool FindDoor = false;

    public GameObject Chair;
    public GameObject ChairCheck;
    public bool checkChair=false;
    public bool FindChair = false;

    public GameObject Desk;
    public GameObject DeskCheck;
    public bool checkDesk = false;
    public bool FindDesk = false;

    public GameObject Drawer;
    public GameObject DrawerCheck;
    public bool checkDrawer = false;
    public bool FindDrawer = false;

    public GameObject WaterTap;
    public GameObject WaterTapCheck;
    public bool checkWaterTap = false;
    public bool FindWaterTap = false;




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
        if (Door.activeSelf == true)
        {
            FindDoor = true;
        }
        if (Chair.activeSelf == true)
        {
            FindChair = true;
        }
        if (Desk.activeSelf == true)
        { 
            FindDesk = true;
        }
        if (WaterTap.activeSelf == true)
        {
            FindWaterTap = true;
        }
        if (Drawer.activeSelf == true)
        {
            FindDrawer = true;
        }


        if (FindDoor == true)
        {
            if (Door.activeSelf == false)
            {
                if (DoorCheck.activeSelf == true && checkDoor == false)
                {
                    Debug.Log("�� ���޽��� ���");
                    checkDoor = true;
                    failed.FailedSecondCamera();
                }
            }
        }
        if (FindChair == true)
        {
            if (Chair.activeSelf == false)
            {
                if (ChairCheck.activeSelf == true && checkChair == false)
                {
                    Debug.Log("���� ���޽��� ���");
                    checkChair = true;
                    failed.FailedSecondCamera();
                }
            }
        }


        if (FindDesk == true)
        {
            if (Desk.activeSelf == false)
            {
                if (DeskCheck.activeSelf == true && checkDesk == false)
                {
                    Debug.Log("Ź�� ���޽��� ���");
                    checkDesk = true;
                    failed.FailedSecondCamera();
                }
            }
        }

        if (FindDrawer == true)
        {
            if (Drawer.activeSelf == false)
            {
                if (DrawerCheck.activeSelf == true && checkDrawer == false)
                {
                    Debug.Log("������ ���޽��� ���");
                    checkDrawer = true;
                    failed.FailedSecondCamera();
                }
            }
        }

        if (FindWaterTap == true)
        {
            if (WaterTap.activeSelf == false)
            {
                if (WaterTapCheck.activeSelf == true && checkWaterTap == false)
                {
                    Debug.Log("�������� ���޽��� ���");
                    checkWaterTap = true;
                    failed.FailedSecondCamera();
                }
            }
        }

    }
}
