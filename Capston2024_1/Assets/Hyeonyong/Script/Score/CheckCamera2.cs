using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera2 : MonoBehaviour
{

    public Camera cameraToCheck; // Camera ������Ʈ�� ���۷����� ���� ����
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������'
                                 // public GameObject Camera_light;




    FingerPrintObject fingerprintobject;

    private int third_score = 0; //�и����� �� �Ŀ� ������ ���� ���

    private bool first_check = false; //�и����� �ϱ� ���� ������ ������� Ȯ��
    private bool second_check = false;//�и����� �� �Ŀ� ������ ������� Ȯ��

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed = false;
    private bool first_Failed_check = false; //�и� �� �� ���� x���� ��� �޽����� �� ���� ���� ����


    public GameObject tape;
    FingerPrintTape fingerprinttape; //�������� �����Ǵ� ��ũ��Ʈ
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

        fingerprinttape = tape.GetComponent<FingerPrintTape>(); //�������� �ִ� ������Ʈ ��������
        // �巯�� ������ �Կ����� �ʰ� �������� �ٿ��� ���� ����
    }

    private float MaxDistance = 0.4f; //����ĳ��Ʈ �Ÿ�(ī�޶�  �Կ� �Ÿ���� �����ص� ��)
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //A��ư�� ���� ���
        {
            Debug.Log("ī�޶� ���� üũ ����");

            // Cube ������Ʈ�� Camera�� ���� ���̴��� Ȯ��
            if (cameraToCheck != null)
            {

                RaycastHit hit; //����ĳ��Ʈ�� �ε����� ��
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;

                ///ó�� �õ� �ÿ��� �Ÿ� üũ x
                if (fingerprintobject.isVisible == true)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    {
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 )
                        {
                            // �ٸ� ��ü�� ������ ������ "False" ���
                            // Check.text = "False1";
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("�ٸ� ��ü�� ������ �ִ�." + hiddenObjectName);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("�Ÿ�����");
                        return;
                    }
                }

                Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);
                if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                     viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                {

                    if (fingerprintobject.isVisible == true && second_check != true && second_Failed == false) // �и����� �� �� ������ ����� ���
                    {
                        third_score += 15;
                        second_check = true;
                        Debug.Log("�и����� �� �� ������ �����.");
                    }
                    Score3.text = "" + third_score;
                    Debug.Log("True");
                }
                else
                {
                    Debug.Log("��ü�� ī�޶� �ȿ� ����.");

                }
            }
        }
    }
}
