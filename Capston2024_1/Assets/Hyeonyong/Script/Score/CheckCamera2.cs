using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera2 : MonoBehaviour
{

    public Camera cameraToCheck; // Camera 오브젝트의 레퍼런스를 받을 변수
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // 카메라 프리팹
    public GameObject RightHand; // 카메라 프리팹'
                                 // public GameObject Camera_light;




    FingerPrintObject fingerprintobject;

    private int third_score = 0; //분말법을 한 후에 사진을 찍을 경우

    private bool first_check = false; //분말법을 하기 전에 사진을 찍었는지 확인
    private bool second_check = false;//분말법을 한 후에 사진을 찍었는지 확인

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed = false;
    private bool first_Failed_check = false; //분말 법 전 사진 x시의 경고 메시지를 한 번만 띄우기 위함


    public GameObject tape;
    FingerPrintTape fingerprinttape; //테이프가 생성되는 스크립트
    private bool second_Failed = false;


    public GameObject other;

    public GameObject other1;
    public GameObject other2;
    public GameObject other3;


    public TextMeshProUGUI Score3; 
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
        if (OVRInput.GetDown(OVRInput.Button.One)) //A버튼을 누를 경우
        {
            Debug.Log("카메라 점수 체크 시작");

            // Cube 오브젝트가 Camera에 의해 보이는지 확인
            if (cameraToCheck != null)
            {

                RaycastHit hit; //레이캐스트와 부딪히는 것
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;

                ///처음 시도 시에는 거리 체크 x
                if (fingerprintobject.isVisible == true)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    {
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 )
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
                if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                     viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                {

                    if (fingerprintobject.isVisible == true && second_check != true && second_Failed == false) // 분말법을 한 후 사진을 찍었을 경우
                    {
                        third_score += 15;
                        second_check = true;
                        Debug.Log("분말법을 한 후 사진을 찍었다.");
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
