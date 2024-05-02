using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLoaction : MonoBehaviour

{
    private bool isGrabbed;
    private bool insideSlot;
    public bool Snapped;

    public GameObject SlotItem;
    public GameObject SlotRotation;

    //Slot에 놓을 경우 item 상태
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == SlotItem.name)
        {
            insideSlot = true;
        }
    }

    //Slot에 놓지 않은 경우 item 상태
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == SlotItem.name)
        {
            insideSlot = false;
        }
    }


    void SlotItemObject()
    {
        if (isGrabbed == false && insideSlot == true)    //아이템이 slot에 장착된 경우
        {
            SlotItem.gameObject.transform.position = transform.position;
            SlotItem.gameObject.transform.rotation = SlotRotation.transform.rotation;
            SlotItem.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);    //사이즈 작아지도록 변경
            Snapped = true;     //snap 상태 true
        }
        else // 아이템을 slot에서 장착 해제한 경우
        {
            SlotItem.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);       //원래 사이즈 되돌아옴
        }

    }

    void Update()
    {
        isGrabbed = SlotItem.GetComponent<OVRGrabbable>().isGrabbed;
        SlotItemObject();
    }
}