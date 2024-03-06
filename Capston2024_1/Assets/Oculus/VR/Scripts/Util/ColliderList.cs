// 분류 : UI > Inventory
// 위치 : Assets > Oculus > VR > Script > Util
// 설명 : detect if an object is colliding with another game object with a "Slot" tag.
//        attached this script to all the Item game objects. 
// 비고 : 유튜브영상 참고한 후 생긴 이슈 -> 댓글 참고하여 작성 (Slot.cs, Item.cs과 같은 위치여야함.)

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
