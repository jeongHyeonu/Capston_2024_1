using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingEvidence : MonoBehaviour
{
    public GameObject EvidenceObj;  // 밀봉 전 증거물 object
    public GameObject PackedObj;    // 밀봉 후 증거물 object

    private bool isGrabbed = false;  // grab 상태 false로 초기화

    public void PackEvidence()
    {

        //컨트롤러 Y버튼 누르면 증거물 packed
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
