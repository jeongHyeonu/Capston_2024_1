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
        if (other.gameObject.name == SlotItem.name)
        {
            insideSlot = true;
        }
    }

    //Slot�� ���� ���� ��� item ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == SlotItem.name)
        {
            insideSlot = false;
        }
    }


    void SlotItemObject()
    {
        if (isGrabbed == false && insideSlot == true)    //�������� slot�� ������ ���
        {
            SlotItem.gameObject.transform.position = transform.position;
            SlotItem.gameObject.transform.rotation = SlotRotation.transform.rotation;
            SlotItem.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);    //������ �۾������� ����
            Snapped = true;     //snap ���� true
        }
        else // �������� slot���� ���� ������ ���
        {
            SlotItem.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);       //���� ������ �ǵ��ƿ�
        }

    }

    void Update()
    {
        isGrabbed = SlotItem.GetComponent<OVRGrabbable>().isGrabbed;
        SlotItemObject();
    }
}