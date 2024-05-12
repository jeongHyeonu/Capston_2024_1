using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckCard : MonoBehaviour
{
    public Camera cameraToCheck; // Camera 오브젝트의 레퍼런스를 받을 변수
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // 카메라 프리팹
    public GameObject RightHand; // 카메라 프리팹
    public GameObject HandTrigger;
    private float MaxDistance = 0.4f; //레이캐스트 거리(카메라  촬영 거리라고 생각해도 됨)

    public GameObject Near;

    public bool onCheckCard=false;


    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject CameraObject = GameObject.Find("CameraView");
        cameraToCheck=CameraObject.GetComponent<Camera>();
        Player = GameObject.Find("OVRPlayerContoroller");
        Cam = GameObject.Find("Camera");
        RightHand = GameObject.Find("RIGHTHANDTRIGGER");
        HandTrigger = GameObject.Find("RIGHTHANDTRIGGER");

        Near = GameObject.Find("Near");
        if (Player == null)
        {
            Debug.Log("플레이어 객체 없음");
        }
        if (Cam == null)
        {
            Debug.Log("카메라 객체 없음");
        }
        if (RightHand == null)
        {
            Debug.Log("오른손 객체 없음");
        }
        if (HandTrigger == null)
        {
            Debug.Log("오른손 객체 없음");
        }

        if (Near == null)
        {
            Debug.Log("Near 객체 없음");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //A버튼을 누를 경우
        {
            // Cube 오브젝트가 Camera에 의해 보이는지 확인
            if (cameraToCheck != null)
            {

                RaycastHit hit; //레이캐스트와 부딪히는 것
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;
                // 카메라와 원하는 객체와의 거리
                // Cube와 Camera 사이에 다른 객체가 있는지 Raycast를 통해 확인
                if (Physics.Raycast(transform.position, rayDirection, out hit))
                //카메라와 객체 사이에 무언가 부딪힐 경우z
                {
                    //인식하고자 하는 객체와 카메라, 플레이어 오브젝트가 가리는 것은 제외
                    if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Near)
                    {
                        // 다른 객체로 가려져 있으면 "False" 출력
                        // Check.text = "False1";
                        string hiddenObjectName = hit.collider.gameObject.name;
                        Debug.Log("CheckCard 다른 객체로 가려져 있다." + hiddenObjectName);
                        return;
                    }
                }
                else
                {
                    Debug.Log("거리부족");
                    return;
                }

                Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);
                //  인식하고자 하는 오브젝트 위치를 카메라에 대한 뷰포트 좌표로 변환

                if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                     viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                {
                    if(gameObject.name=="Door1")
                    {
                        GameObject onscore = GameObject.Find("1-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else {
                            Debug.Log("score가 없다.");
                        }
                    }

                    if (gameObject.name == "Chair1")
                    {
                        GameObject onscore = GameObject.Find("2-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }

                    if (gameObject.name == "Desk1")
                    {
                        GameObject onscore = GameObject.Find("3-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }

                    if (gameObject.name == "Drawer1")
                    {
                        GameObject onscore = GameObject.Find("4-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }

                    if (gameObject.name == "WaterTap1")
                    {
                        GameObject onscore = GameObject.Find("5-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }

                    if (gameObject.name == "Soju")
                    {
                        GameObject onscore = GameObject.Find("1-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }


                    if (gameObject.name == "WhiskyGlass")
                    {
                        GameObject onscore = GameObject.Find("2-7");
                        score = (TextMeshProUGUI)onscore.GetComponent("TextMeshProUGUI");
                        if (score != null)
                        {
                            score.text = "" + 15;
                        }
                        else
                        {
                            Debug.Log("score가 없다.");
                        }
                    }

                    onCheckCard = true;
                }
        }
    }
}

}
