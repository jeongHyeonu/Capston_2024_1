// �з� : UI > Inventory
// ��ġ : Assets > Oculus > VR > Script > Util
// ���� : detect if an object is colliding with another game object with a "Slot" tag.
//        attached this script to all the Item game objects. 
// ��� : ��Ʃ�꿵�� ������ �� ���� �̽� -> ��� �����Ͽ� �ۼ� (Slot.cs, Item.cs�� ���� ��ġ������.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderList : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> m_colliders;

    public List<GameObject> getColliderList
    {
        get { return m_colliders; }
    }

    private void Start()
    {
        m_colliders = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Slot") m_colliders.Add(obj);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Slot") m_colliders.Remove(obj);
    }
}
