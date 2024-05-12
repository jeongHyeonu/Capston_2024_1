using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckCard : MonoBehaviour
{
    public Camera cameraToCheck; // Camera ������Ʈ�� ���۷����� ���� ����
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������
    public GameObject HandTrigger;
    private float MaxDistance = 0.4f; //����ĳ��Ʈ �Ÿ�(ī�޶�  �Կ� �Ÿ���� �����ص� ��)

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
            Debug.Log("�÷��̾� ��ü ����");
        }
        if (Cam == null)
        {
            Debug.Log("ī�޶� ��ü ����");
        }
        if (RightHand == null)
        {
            Debug.Log("������ ��ü ����");
        }
        if (HandTrigger == null)
        {
            Debug.Log("������ ��ü ����");
        }

        if (Near == null)
        {
            Debug.Log("Near ��ü ����");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //A��ư�� ���� ���
        {
            // Cube ������Ʈ�� Camera�� ���� ���̴��� Ȯ��
            if (cameraToCheck != null)
            {

                RaycastHit hit; //����ĳ��Ʈ�� �ε����� ��
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;
                // ī�޶�� ���ϴ� ��ü���� �Ÿ�
                // Cube�� Camera ���̿� �ٸ� ��ü�� �ִ��� Raycast�� ���� Ȯ��
                if (Physics.Raycast(transform.position, rayDirection, out hit))
                //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                {
                    //�ν��ϰ��� �ϴ� ��ü�� ī�޶�, �÷��̾� ������Ʈ�� ������ ���� ����
                    if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Near)
                    {
                        // �ٸ� ��ü�� ������ ������ "False" ���
                        // Check.text = "False1";
                        string hiddenObjectName = hit.collider.gameObject.name;
                        Debug.Log("CheckCard �ٸ� ��ü�� ������ �ִ�." + hiddenObjectName);
                        return;
                    }
                }
                else
                {
                    Debug.Log("�Ÿ�����");
                    return;
                }

                Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);
                //  �ν��ϰ��� �ϴ� ������Ʈ ��ġ�� ī�޶� ���� ����Ʈ ��ǥ�� ��ȯ

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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
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
                            Debug.Log("score�� ����.");
                        }
                    }

                    onCheckCard = true;
                }
        }
    }
}

}
