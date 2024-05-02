using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapItem : MonoBehaviour
{
    public GameObject SnapPos;
    public GameObject Slot;
    public bool isSnapped;
    private bool isItemSnapped;

    private bool isGrabbed;



    // Update is called once per frame
    void Update()
    {
        // item�� ��Ҵ��� Ȯ��
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        // item�� slot�� �ִ��� Ȯ��
        isItemSnapped = SnapPos.GetComponent<SnapLoaction>().Snapped;

        if (isItemSnapped == true)   // item�� Slot�� �־��� ���
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(Slot.transform);
            isSnapped = true;
        }

        if (isItemSnapped == false && isGrabbed == false)    // item�� Slot�� �� ���� ����&&�տ��� ������ ��
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}