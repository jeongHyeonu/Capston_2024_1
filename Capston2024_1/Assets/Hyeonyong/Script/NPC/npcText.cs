using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class npcText : MonoBehaviour
{

    public Transform TextPos; //텍스트 위치
    public Transform Canvas; //텍스트 캔버스

    public Vector3 firstPos; //캔버스 처음 위치
    public Quaternion firstRot; //캔버스 처음 각도
    public TextMeshProUGUI npc; //npc1에 대한 텍스트

    public bool onFailed=false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.position = Canvas.position + new Vector3(100f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Clean();
        }*/
    }


    // 증거물 사진을 촬영하지 않고 분말법을 시행했을 때
    public void FailedFirstCamera() //CheckCamera관련
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "first Camera Failed";
        StartCoroutine(Clean());
    }


    // 분말의 양이 적거나 많을 때
    public void FailedAmountPowder()
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Amount Powder Failed";
        StartCoroutine(Clean());
    }

    // 분말의 색상이 적절하지 않을 때
    public void FailedColorPowder()
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Color Powder Failed";
        StartCoroutine(Clean());
    }


    // 드러난 지문을 촬영하지 않고 테이프를 붙였을 때
    public void FailedSecondCamera() //checkCamera와 FingerPrintTape 관련
    {
        Debug.Log("2번 카메라 실패");
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Second Camera Failed";
        StartCoroutine(Clean());
    }

    // 전사지를 촬영하지 않고 npc에게 제출했을 때
    public void FailedThirdCamera() //fingerPrintPaper와 CheckCamera 관련
    {
        onFailed = true;
        Canvas.transform.localPosition = new Vector3(0f, 1f, 0f);
        npc.text = "Third Camera Failed";
        StartCoroutine(Clean());
    }

    
    IEnumerator Clean() {
        
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                Debug.Log(" B 버튼 눌림");
                Canvas.transform.position = Canvas.transform.position + new Vector3(100f, 0f, 0f);
                onFailed = false;
            }
            yield return new WaitForSeconds(0); // _time 만큼 쉬었다가
            if (onFailed)
            {
                StartCoroutine(Clean()); 
            }

        }
    /*
    public void Clean()
    {    
        Debug.Log(" B 버튼 눌림 npc Text 보내기");
        Canvas.transform.localPosition = Canvas.transform.localPosition + new Vector3(0f, 100f, 0f);             
    }
    */
}
