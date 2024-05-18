using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkCamera_Liquid2_2 : MonoBehaviour
{
    // 이 코드는 카메라에 원하는 객체를 인식시키기 위해 사용하는 코드이다. 현재 간단한 프로토타입만 제작됨
    public Camera cameraToCheck; // Camera 오브젝트의 레퍼런스를 받을 변수
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // 카메라 프리팹
    public GameObject RightHand; // 카메라 프리팹'
    public GameObject Camera_light;


    FingerPrintLiquidScore2 fingerprintliquid;

    private int third_score = 0; //분말법을 한 후에 사진을 찍을 경우

    private bool first_check = false; //분말법을 하기 전에 사진을 찍었는지 확인
    private bool second_check = false;//분말법을 한 후에 사진을 찍었는지 확인

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed = false;
    private bool first_Failed_check = false; //분말 법 전 사진 x시의 경고 메시지를 한 번만 띄우기 위함


    private bool second_Failed = false;


    public GameObject other;

    public GameObject other1;

    public GameObject other2;
    public GameObject other3;
    public GameObject other4;




    public bool doing = false; // 현재 다른 작업을 수행중인지 확인하는 코드.



    public OnLight CheckLight;

    public TextMeshProUGUI Score3; 
    void Start()
    {
        fingerprintliquid = GetComponent<FingerPrintLiquidScore2>();

        failed = HandTrigger.GetComponent<npcText>();


        CheckLight = GetComponent<OnLight>();
    }


    private float MaxDistance = 5f; //레이캐스트 거리(카메라  촬영 거리라고 생각해도 됨)
    void Update()
    {


        if (fingerprintliquid.liquidTriggered == true && first_check != true && first_Failed == false)
        {
            first_Failed = true;
            //액체에 담구기 전에 사진을 찍지 않았을 경우
            //failed.FailedFirstCamera_Liquid();
        }

        if (OVRInput.GetDown(OVRInput.Button.One)) //A버튼을 누를 경우
        {
            // Cube 오브젝트가 Camera에 의해 보이는지 확인
            if (cameraToCheck != null)
            {

                RaycastHit hit; //레이캐스트와 부딪히는 것
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;
                if (fingerprintliquid.liquidTriggered == false)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    //카메라와 객체 사이에 무언가 부딪힐 경우z
                    {
                        //인식하고자 하는 객체와 카메라, 플레이어 오브젝트가 가리는 것은 제외
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 && hit.collider.gameObject != other4)
                        {
                            // 다른 객체로 가려져 있으면 "False" 출력
                            // Check.text = "False1";
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("(액체법)다른 객체로 가려져 있다." + hiddenObjectName);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("거리부족");
                        return;
                    }
                }

                // 2번째 시도에서는 근접에서 촬영하므로 거리 체크 O
                if (fingerprintliquid.liquidTriggered == true)
                {

                    if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))
                    //카메라와 객체 사이에 무언가 부딪힐 경우z
                    {
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 && hit.collider.gameObject != other4)
                        {
                            // 다른 객체로 가려져 있으면 "False" 출력
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("(액체법)다른 객체로 가려져 있다." + hiddenObjectName);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("거리부족");
                        return;
                    }
                }




                    Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);

                    if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                         viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                    {
                        if (fingerprintliquid.liquidTriggered == false && first_check != true) // 분말법을 하기 전 사진을 찍었을 경우
                        {
                            first_check = true;
                            Debug.Log("용액에 담구기 전 사진을 찍었다..");
                        }

                        if (fingerprintliquid.hairLiquidTriggered == true && second_check != true && second_Failed == false) // 분말법을 한 후 사진을 찍었을 경우
                        {
                            third_score = 15;
                            second_check = true;
                            Debug.Log("헤어드라이기 사용 후 사진을 찍었다..");


                            doing = false;
                        }

                        Score3.text = "" + third_score;
                        Debug.Log("True");
                    }
                    else
                    {
                        Debug.Log("객체가 카메라 안에 없다.");

                    }
                }
            }
        }
    }

