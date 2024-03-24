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

    //Slot�� ���� ��� item ����
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == SlotItem.name)
        {
            insideSlot = true;
        }
    }

    //Slot�� ���� ���� ���item ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == SlotItem.name)
        {
            insideSlot = false;
        }
    }


    void SlotItemObject()
    {
        if(isGrabbed == false && insideSlot == true)
        {
            SlotItem.gameObject.transform.position = transform.position;
            SlotItem.gameObject.transform.rotation = SlotRotation.transform.rotation;
            Snapped = true;
        }

    }

    void Update()
    {
        isGrabbed = SlotItem.GetComponent<OVRGrabbable>().isGrabbed;
        SlotItemObject();
    }
}
