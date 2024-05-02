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
        // item을 잡았는지 확인
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        // item이 slot에 있는지 확인
        isItemSnapped = SnapPos.GetComponent<SnapLoaction>().Snapped;

        if (isItemSnapped == true)   // item을 Slot에 넣었을 경우
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(Slot.transform);
            isSnapped = true;
        }

        if (isItemSnapped == false && isGrabbed == false)    // item을 Slot에 안 넣은 상태&&손에서 놓았을 때
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}