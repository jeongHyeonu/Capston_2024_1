using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCameraClicked : MonoBehaviour
{

    public GameObject Camera;
    public GameObject CameraPos;
    public GameObject OutsideCameraPos;

    public static bool CameraActive; //FlashLightActive Ȱ�� ���� ����


    // inside map
    public void InTransCamera()
    {
        Camera.transform.position = CameraPos.transform.position;
        Camera.transform.rotation = CameraPos.transform.rotation;
        CameraActive = true;
    }

    //outside map
    public void OutTransCamera()
    {
        Camera.transform.position = OutsideCameraPos.transform.position;
        CameraActive = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        OutTransCamera();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
