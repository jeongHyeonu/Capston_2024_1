using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    // �� �ڵ�� ī�޶� ���ϴ� ��ü�� �νĽ�Ű�� ���� ����ϴ� �ڵ��̴�. ���� ������ ������Ÿ�Ը� ���۵�
    public Camera cameraToCheck; // Camera ������Ʈ�� ���۷����� ���� ����
    public TextMeshPro Score; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public TextMeshPro Score2; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������'
    public GameObject Camera_light;




    FingerPrintObject fingerprintobject;
    private int first_score = 0; //�и����� �ϱ� ���� ������ ���� ���
    private int second_score = 0; //�и����� �� �Ŀ� ������ ���� ���

    private bool first_check = false; //�и����� �ϱ� ���� ������ ������� Ȯ��
    private bool second_check = false;//�и����� �� �Ŀ� ������ ������� Ȯ��

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed=false;
    private bool first_Failed_check = false; //�и� �� �� ���� x���� ��� �޽����� �� ���� ���� ����


    public GameObject tape;
    FingerPrintTape fingerprinttape; //�������� �����Ǵ� ��ũ��Ʈ
    private bool second_Failed = false;


    public GameObject other;

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
        if (fingerprintobject.isVisible == true && first_check != true&& first_Failed==false)
        {
            first_Failed = true;
            //0424 �и��� ���� ������ ���� �ʾ��� ���
            failed.FailedFirstCamera();
        }

        if (fingerprinttape.onTape == true && second_check == false && second_Failed == false)
        {
            Debug.Log("2��° ī�޶� ���� in CheckCamera");
            second_Failed = true;
            //0424 �и��� ���� ������ ���� �ʾ��� ���
            failed.FailedSecondCamera();
            fingerprinttape.onTape = false;
        }

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
                //if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))

                ///ó�� �õ� �ÿ��� �Ÿ� üũ x
                if (fingerprintobject.isVisible == false)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                    {
                        //�ν��ϰ��� �ϴ� ��ü�� ī�޶�, �÷��̾� ������Ʈ�� ������ ���� ����
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other)
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

                // 2��° �õ������� �������� �Կ��ϹǷ� �Ÿ� üũ O
                if (fingerprintobject.isVisible == true)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))
                    //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                    {
                        //�ν��ϰ��� �ϴ� ��ü�� ī�޶�, �÷��̾� ������Ʈ�� ������ ���� ����
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other)
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
                        first_score+=15;
                        first_check = true;
                        Debug.Log("�и����� �ϱ� �� ������ �����.");

                        //Check.text = "first";
                    }

                    if (fingerprintobject.isVisible == true && second_check != true && second_Failed==false) // �и����� �� �� ������ ����� ���
                    {
                        second_score+=15;
                        second_check = true;
                        Debug.Log("�и����� �� �� ������ �����.");
                        //Check.text = "Succeed";
                    }

                    /*
                    if (first_check == false && second_check == true&&first_Failed_check==false)
                    {
                        Debug.Log("�и����� �ϱ� �� ������ ���� �ʾҴ�.");

                        first_Failed_check=true; //1���� ����.
                        //0424 �и��� ���� ������ ����� ���
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
                Debug.Log("��ü�� ī�޶� �ȿ� ����.");

                }
            }
        }
    }
}
