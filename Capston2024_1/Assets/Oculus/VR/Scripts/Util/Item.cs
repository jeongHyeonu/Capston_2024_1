// 분류 : UI > Inventory
// 위치 : Assets > Oculus > VR > Scripts > Util
// 이름 : Item
// 설명 : 인벤토리에 넣을 아이템
// 비고 : 위치가 Oculus에 있는 이유?
//       = OVRGrabbable.cs에 내용을 추가하기 위해 같은 위치에 있어야함.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool inSlot;
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot;

}