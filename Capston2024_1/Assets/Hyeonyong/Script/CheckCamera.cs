using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    // 이 코드는 카메라에 원하는 객체를 인식시키기 위해 사용하는 코드이다. 현재 간단한 프로토타입만 제작됨
    public Camera cameraToCheck; // Camera 오브젝트의 레퍼런스를 받을 변수
    public TextMeshPro Score; // 그냥 체크용으로 넣어둔 것이라 나중에 지울 예정
    public TextMeshPro Score2; // 그냥 체크용으로 넣어둔 것이라 나중에 지울 예정
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // 카메라 프리팹
    public GameObject RightHand; // 카메라 프리팹'
    public GameObject Camera_light;




    FingerPrintObject fingerprintobject;
    private int first_score = 0; //분말법을 하기 전에 사진을 찍을 경우
    private int second_score = 0; //분말법을 한 후에 사진을 찍을 경우

    private bool first_check = false; //분말법을 하기 전에 사진을 찍었는지 확인
    private bool second_check = false;//분말법을 한 후에 사진을 찍었는지 확인

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed=false;
    private bool first_Failed_check = false; //분말 법 전 사진 x시의 경고 메시지를 한 번만 띄우기 위함


    public GameObject tape;
    FingerPrintTape fingerprinttape; //테이프가 생성되는 스크립트
    private bool second_Failed = false;


    public GameObject other;

    void Start()
    {
        fingerprintobject = GetComponent<FingerPrintObject>();

        failed = HandTrigger.GetComponent<npcText>();

        fingerprinttape = tape.GetComponent<FingerPrintTape>(); //테이프에 있는 컴포넌트 가져오기
        // 드러난 지문을 촬영하지 않고 테이프를 붙였을 때를 위함
    }

    private float MaxDistance = 0.4f; //레이캐스트 거리(카메라  촬영 거리라고 생각해도 됨)
    void Update()
    {
        if (fingerprintobject.isVisible == true && first_check != true&& first_Failed==false)
        {
            first_Failed = true;
            //0424 분말법 전에 사진을 찍지 않았을 경우
            failed.FailedFirstCamera();
        }

        if (fingerprinttape.onTape == true && second_check == false && second_Failed == false)
        {
            Debug.Log("2번째 카메라 실패 in CheckCamera");
            second_Failed = true;
            //0424 분말법 전에 사진을 찍지 않았을 경우
            failed.FailedSecondCamera();
            fingerprinttape.onTape = false;
        }

        //if (OVRInput.GetDown(OVRInput.Button.Three)) //X버튼을 누를 경우
        if (OVRInput.GetDown(OVRInput.Button.One)) //A버튼을 누를 경우
        {
            // Cube 오브젝트가 Camera에 의해 보이는지 확인
            if (cameraToCheck != null)
            {

                RaycastHit hit; //레이캐스트와 부딪히는 것
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;
                // 카메라와 원하는 객체와의 거리
                // Cube와 Camera 사이에 다른 객체가 있는지 Raycast를 통해 확인
                //if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))

                ///처음 시도 시에는 거리 체크 x
                if (fingerprintobject.isVisible == false)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    //카메라와 객체 사이에 무언가 부딪힐 경우z
                    {
                        //인식하고자 하는 객체와 카메라, 플레이어 오브젝트가 가리는 것은 제외
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other)
                        {
                            // 다른 객체로 가려져 있으면 "False" 출력
                            // Check.text = "False1";
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("다른 객체로 가려져 있다." + hiddenObjectName);
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
                if (fingerprintobject.isVisible == true)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))
                    //카메라와 객체 사이에 무언가 부딪힐 경우z
                    {
                        //인식하고자 하는 객체와 카메라, 플레이어 오브젝트가 가리는 것은 제외
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other)
                        {
                            // 다른 객체로 가려져 있으면 "False" 출력
                            // Check.text = "False1";
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("다른 객체로 가려져 있다." + hiddenObjectName);
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
                //  인식하고자 하는 오브젝트 위치를 카메라에 대한 뷰포트 좌표로 변환

                // 만약 Cube가 Camera의 시야 안에 있으면 "True" 출력
                //아래 값은 임의로 작성된 값이며 수정이 가능하다.
                /* if (viewportPoint.x > 0.25 && viewportPoint.x < 0.75 &&
                     viewportPoint.y > 0.25 && viewportPoint.y < 0.75 && viewportPoint.z > 0)*/
                //수치 간격이 좁을수록 정확한 위치에 맞춰야 한다.
                /*if (viewportPoint.x > 0.35 && viewportPoint.x < 0.65&&
                     viewportPoint.y > 0.35 && viewportPoint.y < 0.65 && viewportPoint.z > 0)*/
                if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                     viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                {


                    //0402자 수정 사진을 정상적으로 찍었는지 체크하는 예외처리
                    if (fingerprintobject.isVisible == false&& first_check!=true) // 분말법을 하기 전 사진을 찍었을 경우
                    {
                        first_score+=15;
                        first_check = true;
                        Debug.Log("분말법을 하기 전 사진을 찍었다.");

                        //Check.text = "first";
                    }

                    if (fingerprintobject.isVisible == true && second_check != true && second_Failed==false) // 분말법을 한 후 사진을 찍었을 경우
                    {
                        second_score+=15;
                        second_check = true;
                        Debug.Log("분말법을 한 후 사진을 찍었다.");
                        //Check.text = "Succeed";
                    }

                    /*
                    if (first_check == false && second_check == true&&first_Failed_check==false)
                    {
                        Debug.Log("분말법을 하기 전 사진을 찍지 않았다.");

                        first_Failed_check=true; //1번만 띄운다.
                        //0424 분말법 전에 사진을 찍었을 경우
                        failed.FailedFirstCamera();
                        //Check.text = "OnlySecond";
                    }
                    */

                    //Score.text = "F=" + first_score + " S=" + second_score;
                    Score.text = ""+first_score;
                    Score2.text = ""+second_score;
                    //Check.text = "True";
                    Debug.Log("True");
                }
                else
                {
               // Check.text = "False2";
                Debug.Log("객체가 카메라 안에 없다.");

                }
            }
        }
    }
}
