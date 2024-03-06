// �з� : UI > Inventory
// ��ġ : Assets > Oculus > VR > Scripts > Util
// �̸� : Slot
// ���� : �κ��丮 Slot
// ��� : ��ġ�� Oculus�� �ִ� ����?
//       = OVRGrabbable.cs�� ������ �߰��ϱ� ���� ���� ��ġ�� �־����.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;   //
    public Image slotImage;     //slot�� canvas > image
    Color originalColor;    //���� ����

    bool lastFrameGrabbed;  //****�߰�����


    void Start()
    {
        // ���۽�, Slot�� image������ default 
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
        lastFrameGrabbed = false;       //****�߰�����
    }


    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj)) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }

        //********************�߰��� ����********************
        // This makes sure if you release a grabbed Item while it is colliding with more than 1 Slot, the Item will not get inserted.
        if (obj.GetComponent<ColliderList>().getColliderList.Count > 1) return;

        // If your Slot is colliding with an Item while you're releasing another Item currently being grabbed that isn't colliding with any Slot(s), the collided Item will get inserted into the Slot.
        // To fix this, I added the followings to the Slot script:
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && lastFrameGrabbed == true)
        {
            InsertItem(obj);
        }
        lastFrameGrabbed = obj.GetComponent<OVRGrabbable>().isGrabbed;
        //*****************************************************************

    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        slotImage.color = Color.gray;
    }

    //Slot ���� �ʱ�ȭ
    public void ResetColor()
    {
        slotImage.color = originalColor;
    }

}
