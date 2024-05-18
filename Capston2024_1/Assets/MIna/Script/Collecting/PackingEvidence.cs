using System.Collections;
using UnityEngine;

public class PackingEvidence : MonoBehaviour
{
    public GameObject EvidenceObj;  // �к� �� ���Ź� object
    public GameObject PackedObj;    // �к� �� ���Ź� object

    private bool isGrabbed = false;  // grab ���� false�� �ʱ�ȭ

    public void PackEvidence()
    {
        // ��Ʈ�ѷ� Y��ư ������ ���Ź� packed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Debug.Log("Y ��ư ����, ���Ź� �к� ����");

            // �ӽ� ������ ����Ͽ� ��ġ�� ȸ�� ����
            Vector3 tempPosition = PackedObj.transform.position;
            Quaternion tempRotation = PackedObj.transform.rotation;

            // PackedObj�� EvidenceObj�� ��ġ�� ȸ�� ����
            PackedObj.transform.position = EvidenceObj.transform.position;
            PackedObj.transform.rotation = EvidenceObj.transform.rotation;

            // EvidenceObj�� �ӽ� ������ ����� ��ġ�� ȸ�� ����
            EvidenceObj.transform.position = tempPosition;
            EvidenceObj.transform.rotation = tempRotation;


            EvidenceObj.SetActive(false);
            Debug.Log("EvidenceObj ��Ȱ��ȭ");

            PackedObj.SetActive(true);
            Debug.Log("PackedObj Ȱ��ȭ");

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_2); // ���� �߰� - ������
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
        StartCoroutine(CheckGrabbed());
    }

    public void OffGrab()
    {
        isGrabbed = false;
        StopCoroutine(CheckGrabbed());
    }

    private IEnumerator CheckGrabbed()
    {
        while (isGrabbed)
        {
            PackEvidence();
            yield return null; // ���� �����ӱ��� ���
        }
    }
}
