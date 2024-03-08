using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//카메라를 잡는 코드
public class GrabCamera : MonoBehaviour
{

    public Transform Camera; //카메라 프리팹
    public Transform RightHand; //오른손
    private bool grab = false; //오른손과 충돌 중인가?
    public static bool onCamera=false; //카메라를 손에 쥐었는가?
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log("버튼 눌림");
            //GrabOnHand(); 
            grab = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {

            PutDownCamera();
            grab = false;
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        // 손 콜리더와 충돌했을 때 update문 전용
        /*if (grab==true &&other.CompareTag("RIGHTHAND"))
        {
                GrabOnHand();
        }*/
        if (other.CompareTag("RIGHTHAND"))//0308 코루틴 전용 오른손과 충돌이 일어날 경우
        {
            StartCoroutine(HandCheckCoroutine());
            grab = true;
            Debug.Log("코루틴 시작");
        }
    
    }
    /*
    private void OnTriggerStay(Collider other)
    {
         손 콜리더와 충돌 중일 때
        if (other.CompareTag("RIGHTHAND"))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("버튼 눌림");
                GrabOnHand(); 
                grab = true;
            }
        }
    }*/

    private void OnTriggerExit(Collider other) //0308 코루틴 전용 오른손과 충돌을 끝낼 경우
    {
        if (other.CompareTag("RIGHTHAND"))
        {
            // 코루틴 중단
            StopCoroutine(HandCheckCoroutine());
            grab = false;
            Debug.Log("코루틴 중단");
        }
    }

    // 시간 손이 있는지 체크하는 코루틴 0308
    IEnumerator HandCheckCoroutine()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)&&grab==true)
        {
            Debug.Log("버튼 눌림");
            GrabOnHand(); 
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {

            PutDownCamera();
            //grab = false;
        }
        yield return new WaitForSeconds(0); 
        if (grab == true)
        {
            StartCoroutine(HandCheckCoroutine()); // 재귀적으로 코루틴 실행
        }
    }




    private void GrabOnHand() // 카메라를 오른손의 자식으로 두고 위치를 이동시킨다.
    {
        onCamera = true;
        Debug.Log("잡았다.");
        Camera.transform.SetParent(RightHand);
        Camera.transform.position = RightHand.transform.position;
        Camera.transform.rotation = RightHand.transform.rotation;
    }
    private void PutDownCamera()//카메라와 오른손의 자식관계를 해제한다.
    {
        onCamera = false;
        Debug.Log("놓았다.") ;
        Camera.transform.SetParent(null);
    }
}
