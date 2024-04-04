using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    // 이 코드는 카메라에 원하는 객체를 인식시키기 위해 사용하는 코드이다. 현재 간단한 프로토타입만 제작됨
    // 추가 예정 : 카메라를 촬영할 때만 사용
    public Camera cameraToCheck; // Camera 오브젝트의 레퍼런스를 받을 변수
    public TextMeshProUGUI Check; // 그냥 체크용으로 넣어둔 것이라 나중에 지울 예정
    public TextMeshProUGUI Score; // 그냥 체크용으로 넣어둔 것이라 나중에 지울 예정
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // 카메라 프리팹
    public GameObject RightHand; // 카메라 프리팹




    FingerPrintObject fingerprintobject;
    private int first_score = 0; //분말법을 하기 전에 사진을 찍을 경우
    private int second_score = 0; //분말법을 한 후에 사진을 찍을 경우

    private bool first_check = false; //분말법을 하기 전에 사진을 찍었는지 확인
    private bool second_check = false;//분말법을 한 후에 사진을 찍었는지 확인

    void Start()
    {
        fingerprintobject = GetComponent<FingerPrintObject>();
    }

    void Update()
    {
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
                if (Physics.Raycast(transform.position, rayDirection, out hit))
                    //카메라와 객체 사이에 무언가 부딪힐 경우
                {
                    //인식하고자 하는 객체와 카메라, 플레이어 오브젝트가 가리는 것은 제외
                    if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject&& hit.collider.gameObject !=Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand)
                    {
                    // 다른 객체로 가려져 있으면 "False" 출력
                   // Check.text = "False1";
                    Debug.Log("False1");
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
                        first_score++;
                        first_check = true;
                        Debug.Log("분말법을 하기 전 사진을 찍었다.");

                        Check.text = "first";
                    }

                    if (fingerprintobject.isVisible == true && second_check != true) // 분말법을 한 후 사진을 찍었을 경우
                    {
                        second_score++;
                        second_check = true;
                        Debug.Log("분말법을 한 후 사진을 찍었다.");
                        Check.text = "Succeed";
                    }

                    if (first_check == false && second_check == true)
                    {
                        Debug.Log("분말법을 하기 전 사진을 찍지 않았다.");
                        Check.text = "OnlySecond";
                    }


                    Score.text = "F=" + first_score + " S=" + second_score;
                    //Check.text = "True";
                    Debug.Log("True");
                }
                else
                {
               // Check.text = "False2";
                Debug.Log("False2");

                }
            }
        }
    }
}
