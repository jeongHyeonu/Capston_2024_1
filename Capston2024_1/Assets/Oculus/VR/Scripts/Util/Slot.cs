// 분류 : UI > Inventory
// 위치 : Assets > Oculus > VR > Scripts > Util
// 이름 : Slot
// 설명 : 인벤토리 Slot
// 비고 : 위치가 Oculus에 있는 이유?
//       = OVRGrabbable.cs에 내용을 추가하기 위해 같은 위치에 있어야함.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;   //
    public Image slotImage;     //slot의 canvas > image
    Color originalColor;    //원래 색상

    bool lastFrameGrabbed;  //****추가내용


    void Start()
    {
        // 시작시, Slot의 image색상이 default 
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
        lastFrameGrabbed = false;       //****추가내용
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

        //********************추가한 내용********************
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

    //Slot 색상 초기화
    public void ResetColor()
    {
        slotImage.color = originalColor;
    }

}
