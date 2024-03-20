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
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three)) //X��ư�� ���� ���
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
                    Check.text = "False1";
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
                if (viewportPoint.x > 0.35 && viewportPoint.x < 0.65&
                     viewportPoint.y > 0.35 && viewportPoint.y < 0.65 && viewportPoint.z > 0)
                {
                    Check.text = "True";
                    Debug.Log("True");
                }
                else
                {
                Check.text = "False2";
                Debug.Log("False2");

                }
            }
        }
    }
}
