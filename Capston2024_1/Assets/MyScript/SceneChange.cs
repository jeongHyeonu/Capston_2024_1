using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    bool sChange = false;
    public GameObject CenterEyeObj;  // 오큘러스 CameraRig의 CenterEyeObj 연결
    OVRScreenFade OFade;
    // Start is called before the first frame update
    void Start()
    {
        OFade = CenterEyeObj.transform.GetComponent<OVRScreenFade>();
    }
    private void OnTriggerEnter(Collider other)
    {

        //if (hasTriggered)
        //return;
        // 충돌한 오브젝트의 이름을 확인
        string collidedObjectName = other.gameObject.tag;


        // 충돌한 오브젝트에 따라 새로운 모드 활성화
        switch (collidedObjectName)
        {
            case "Player":    
                Debug.Log("엘리베이터와 충돌");
                sChange = true;
                break;
            default:
                // 다른 오브젝트와의 충돌은 무시
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (sChange == true)
        {
            StartCoroutine(ProcessInput());
        }
    }

    IEnumerator ProcessInput()
    {

        if (OVRInput.GetDown(OVRInput.Button.Two)) // B 버튼 누르면 씬 이동
        {
            OFade.FadeOut();

            yield return new WaitForSeconds(OFade.fadeTime);

            SceneManager.LoadScene("Scene2");

        }
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 누르면 씬 이동
        {
            OFade.FadeOut();

            yield return new WaitForSeconds(OFade.fadeTime);

            SceneManager.LoadScene("Scene2");
        }
    }
}
