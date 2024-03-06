// �з� : UI > Inventory
// ��ġ : Assets > Oculus > VR > Scripts > Util
// �̸� : Item
// ���� : �κ��丮�� ���� ������
// ��� : ��ġ�� Oculus�� �ִ� ����?
//       = OVRGrabbable.cs�� ������ �߰��ϱ� ���� ���� ��ġ�� �־����.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool inSlot;
    public Vector3 slotRotation = Vector3.zero;
    public Slot currentSlot;

}