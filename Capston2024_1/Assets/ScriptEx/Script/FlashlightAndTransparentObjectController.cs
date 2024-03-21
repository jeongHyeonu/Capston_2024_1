using UnityEngine;

public class FlashlightAndTransparentObjectController : MonoBehaviour
{
    // ������ ����
    public Light flashlight;
    // ���� ������Ʈ�� �±�
    public string transparentObjectTag = "TransparentObject";
    // ���� ������Ʈ�� ���� ������ �Ÿ�
    public float distanceThreshold = 5f;
    // ��ŧ���� ��Ʈ�ѷ��� ��ư
    public OVRInput.Button toggleButton = OVRInput.Button.One;

    void Start()
    {
        // ��ŧ���� ��Ʈ�ѷ��� ��ư �Է� Ȯ��
        if (OVRInput.GetDown(toggleButton))
        {
            // ������ �Ѱų� ��
            flashlight.enabled = !flashlight.enabled;
        }
    }

    void Update()
    {
        // ������ ������ �������� ���� ���� ������Ʈ�� ó��
        if (flashlight.enabled)
        {
            // ������ ���� ������Ʈ ������ �Ÿ� ���
            GameObject[] transparentObjects = GameObject.FindGameObjectsWithTag(transparentObjectTag);

            foreach (GameObject transparentObject in transparentObjects)
            {
                float distanceToFlashlight = Vector3.Distance(transparentObject.transform.position, flashlight.transform.position);

                // �Ÿ��� ���� �Ÿ� ������ ��� ������Ʈ�� Ȱ��ȭ
                if (distanceToFlashlight <= distanceThreshold)
                {
                    transparentObject.SetActive(true);
                }
                else
                {
                    // ���� �Ÿ� �̻��� ��� ������Ʈ�� ��Ȱ��ȭ
                    transparentObject.SetActive(false);
                }
            }
        }
    }
}

