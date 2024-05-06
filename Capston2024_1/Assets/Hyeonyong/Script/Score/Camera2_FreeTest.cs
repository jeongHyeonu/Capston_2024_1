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


    //2�� �� �߰� ����


    public GameObject HandTrigger;
    npcText failed;




    void Start()
    {
        failed = HandTrigger.GetComponent<npcText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Door.activeSelf == false &&DoorCheck.activeSelf==true &&checkDoor==false)
        {
            Debug.Log("�� ���޽��� ���");
            checkDoor = true;
            failed.FailedSecondCamera();
        }

        if (Chair.activeSelf == false && ChairCheck.activeSelf == true &&checkChair==false)
        {
            Debug.Log("���� ���޽��� ���");
            checkChair = true;
            failed.FailedSecondCamera();
        }

        if (Desk.activeSelf == false && DeskCheck.activeSelf == true && checkDesk==false)
        {
            Debug.Log("Ź�� ���޽��� ���");
            checkDesk = true;
            failed.FailedSecondCamera();
        }



    }
}
