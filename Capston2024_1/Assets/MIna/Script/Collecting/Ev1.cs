using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ev1 : MonoBehaviour
{
    public GameObject EvidenceObj;
    public GameObject PackedObj;

    public static bool isObjGrabbed;

    public void CollectEvidence()
    {
        
        //��Ʈ�ѷ� Y��ư ������ WristUI Ȱ��/��Ȱ��
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            PackedObj.transform.position = EvidenceObj.transform.position;
            PackedObj.transform.rotation = EvidenceObj.transform.rotation;

            EvidenceObj.SetActive(false);
            PackedObj.SetActive(true);
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollectEvidence();
    }
}
