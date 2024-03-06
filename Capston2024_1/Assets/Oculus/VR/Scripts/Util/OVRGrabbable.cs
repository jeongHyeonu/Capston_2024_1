// 분류 : UI > Inventory (하지만 Script for UI에 없고 Oculus folder에 있는걸 수정 -> 이유: OVRgrabber등 다른 기본 스크립트와 연관있어서)
// 위치 : Assets > Oculus > VR > Script > Util
// 이름 : OVRGrabbable
// 설명 : 인벤토리에 넣을 3D 물건들 상호작용(잡기)에 내용 추가 (Oculus SDK에서 제공하는 상호작용 스크립트 사용)
// 비고 : GrabBegin() 함수에 내용 추가





/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using UnityEngine;

/// <summary>
/// An object that can be grabbed and thrown by OVRGrabber.
/// </summary>
[HelpURL("https://developer.oculus.com/reference/unity/latest/class_o_v_r_grabbable")]
public class OVRGrabbable : MonoBehaviour
{
    [SerializeField]
    protected bool m_allowOffhandGrab = true;

    [SerializeField]
    protected bool m_snapPosition = false;

    [SerializeField]
    protected bool m_snapOrientation = false;

    [SerializeField]
    protected Transform m_snapOffset;

    [SerializeField]
    protected Collider[] m_grabPoints = null;

    protected bool m_grabbedKinematic = false;
    protected Collider m_grabbedCollider = null;
    protected OVRGrabber m_grabbedBy = null;

    /// <summary>
    /// If true, the object can currently be grabbed.
    /// </summary>
    public bool allowOffhandGrab
    {
        get { return m_allowOffhandGrab; }
    }

    /// <summary>
    /// If true, the object is currently grabbed.
    /// </summary>
    public bool isGrabbed
    {
        get { return m_grabbedBy != null; }
    }

    /// <summary>
    /// If true, the object's position will snap to match snapOffset when grabbed.
    /// </summary>
    public bool snapPosition
    {
        get { return m_snapPosition; }
    }

    /// <summary>
    /// If true, the object's orientation will snap to match snapOffset when grabbed.
    /// </summary>
    public bool snapOrientation
    {
        get { return m_snapOrientation; }
    }

    /// <summary>
    /// An offset relative to the OVRGrabber where this object can snap when grabbed.
    /// </summary>
    public Transform snapOffset
    {
        get { return m_snapOffset; }
    }

    /// <summary>
    /// Returns the OVRGrabber currently grabbing this object.
    /// </summary>
    public OVRGrabber grabbedBy
    {
        get { return m_grabbedBy; }
    }

    /// <summary>
    /// The transform at which this object was grabbed.
    /// </summary>
    public Transform grabbedTransform
    {
        get { return m_grabbedCollider.transform; }
    }

    /// <summary>
    /// The Rigidbody of the collider that was used to grab this object.
    /// </summary>
    public Rigidbody grabbedRigidbody
    {
        get { return m_grabbedCollider.attachedRigidbody; }
    }

    /// <summary>
    /// The contact point(s) where the object was grabbed.
    /// </summary>
    public Collider[] grabPoints
    {
        get { return m_grabPoints; }
    }

    /// <summary>
    /// Notifies the object that it has been grabbed.
    /// </summary>
    virtual public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        m_grabbedBy = hand;
        m_grabbedCollider = grabPoint;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //*********inventory를 위해 추가된 내용**********
        // 아이템을 잡을 때를 Slot 안에 이미 있는 아이템인지 아닌지 판단하기 위한 내용.
        //-------------------------------------
        // 아이템이 slot안에 없을 경우 
        if (gameObject.GetComponent<Item>() == null) return;

        // 아이템이 slot안에 있을 경우 
        if (gameObject.GetComponent<Item>().inSlot)
        {
            gameObject.GetComponentInParent<Slot>().ItemInSlot = null;  //Slot안에 아이템 상태 == null로 변경
            gameObject.transform.parent = null;
            gameObject.GetComponent<Item>().inSlot = false;             //
            gameObject.GetComponent<Item>().currentSlot.ResetColor();   //최근 Slot 빈상태의 색상으로 변경
            gameObject.GetComponent<Item>().currentSlot = null;         //최근 Slot 빈상태로 변경
        }
        //*************************************************

    }

    /// <summary>
    /// Notifies the object that it has been released.
    /// </summary>
    virtual public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = m_grabbedKinematic;
        rb.velocity = linearVelocity;
        rb.angularVelocity = angularVelocity;
        m_grabbedBy = null;
        m_grabbedCollider = null;
    }

    void Awake()
    {
        if (m_grabPoints.Length == 0)
        {
            // Get the collider from the grabbable
            Collider collider = this.GetComponent<Collider>();
            if (collider == null)
            {
                throw new ArgumentException("Grabbables cannot have zero grab points and no collider " +
                                            "-- please add a grab point or collider.");
            }

            // Create a default grab point
            m_grabPoints = new Collider[1] { collider };
        }
    }

    protected virtual void Start()
    {
        m_grabbedKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    void OnDestroy()
    {
        if (m_grabbedBy != null)
        {
            // Notify the hand to release destroyed grabbables
            m_grabbedBy.ForceRelease(this);
        }
    }
}
