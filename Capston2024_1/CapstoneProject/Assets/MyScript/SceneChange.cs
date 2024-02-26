using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    bool sChange = false;
    public GameObject CenterEyeObj;  // ��ŧ���� CameraRig�� CenterEyeObj ����
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
        // �浹�� ������Ʈ�� �̸��� Ȯ��
        string collidedObjectName = other.gameObject.tag;


        // �浹�� ������Ʈ�� ���� ���ο� ��� Ȱ��ȭ
        switch (collidedObjectName)
        {
            case "Player":    
                Debug.Log("���������Ϳ� �浹");
                sChange = true;
                break;
            default:
                // �ٸ� ������Ʈ���� �浹�� ����
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

        if (OVRInput.GetDown(OVRInput.Button.Two)) // B ��ư ������ �� �̵�
        {
            OFade.FadeOut();

            yield return new WaitForSeconds(OFade.fadeTime);

            SceneManager.LoadScene("Scene2");

        }
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư ������ �� �̵�
        {
            OFade.FadeOut();

            yield return new WaitForSeconds(OFade.fadeTime);

            SceneManager.LoadScene("Scene2");
        }
    }
}
