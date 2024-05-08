using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingEvidence : MonoBehaviour
{
    public GameObject EvidenceObj;  // �к� �� ���Ź� object
    public GameObject PackedObj;    // �к� �� ���Ź� object

    private bool isGrabbed = false;  // grab ���� false�� �ʱ�ȭ

    public void PackEvidence()
    {

        //��Ʈ�ѷ� Y��ư ������ ���Ź� packed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            PackedObj.transform.position = EvidenceObj.transform.position;
            PackedObj.transform.rotation = EvidenceObj.transform.rotation;

            EvidenceObj.SetActive(false);
            PackedObj.SetActive(true);

        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
    }

    public void OffGrab()
    {
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed == true)
        {
            PackEvidence();
        }
    }


}
