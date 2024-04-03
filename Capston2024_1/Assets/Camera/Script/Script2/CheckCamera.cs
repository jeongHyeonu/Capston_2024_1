using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    // �� �ڵ�� ī�޶� ���ϴ� ��ü�� �νĽ�Ű�� ���� ����ϴ� �ڵ��̴�. ���� ������ ������Ÿ�Ը� ���۵�
    // �߰� ���� : ī�޶� �Կ��� ���� ���
    public Camera cameraToCheck; // Camera ������Ʈ�� ���۷����� ���� ����
    public TextMeshProUGUI Check; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public TextMeshProUGUI Score; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������




    FingerPrintObject fingerprintobject;
    private int first_score = 0; //�и����� �ϱ� ���� ������ ���� ���
    private int second_score = 0; //�и����� �� �Ŀ� ������ ���� ���

    private bool first_check = false; //�и����� �ϱ� ���� ������ ������� Ȯ��
    private bool second_check = false;//�и����� �� �Ŀ� ������ ������� Ȯ��

    void Start()
    {
        fingerprintobject = GetComponent<FingerPrintObject>();
    }

    void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.Three)) //X��ư�� ���� ���
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
                    //ī�޶�� ��ü ���̿� ���� �ε��� ���
                {
                    //�ν��ϰ��� �ϴ� ��ü�� ī�޶�, �÷��̾� ������Ʈ�� ������ ���� ����
                    if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject&& hit.collider.gameObject !=Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand)
                    {
                    // �ٸ� ��ü�� ������ ������ "False" ���
                   // Check.text = "False1";
                    Debug.Log("False1");
                        return;
                    }
                }

                Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);
                //  �ν��ϰ��� �ϴ� ������Ʈ ��ġ�� ī�޶� ���� ����Ʈ ��ǥ�� ��ȯ

                // ���� Cube�� Camera�� �þ� �ȿ� ������ "True" ���
                //�Ʒ� ���� ���Ƿ� �ۼ��� ���̸� ������ �����ϴ�.
                /* if (viewportPoint.x > 0.25 && viewportPoint.x < 0.75 &&
                     viewportPoint.y > 0.25 && viewportPoint.y < 0.75 && viewportPoint.z > 0)*/
                //��ġ ������ �������� ��Ȯ�� ��ġ�� ����� �Ѵ�.
                /*if (viewportPoint.x > 0.35 && viewportPoint.x < 0.65&&
                     viewportPoint.y > 0.35 && viewportPoint.y < 0.65 && viewportPoint.z > 0)*/
                if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                     viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                {


                    //0402�� ���� ������ ���������� ������� üũ�ϴ� ����ó��
                    if (fingerprintobject.isVisible == false&& first_check!=true) // �и����� �ϱ� �� ������ ����� ���
                    {
                        first_score++;
                        first_check = true;
                        Debug.Log("�и����� �ϱ� �� ������ �����.");

                        Check.text = "first";
                    }

                    if (fingerprintobject.isVisible == true && second_check != true) // �и����� �� �� ������ ����� ���
                    {
                        second_score++;
                        second_check = true;
                        Debug.Log("�и����� �� �� ������ �����.");
                        Check.text = "Succeed";
                    }

                    if (first_check == false && second_check == true)
                    {
                        Debug.Log("�и����� �ϱ� �� ������ ���� �ʾҴ�.");
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
