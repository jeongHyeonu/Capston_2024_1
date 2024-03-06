// 분류 : UI > Inventory
// 위치 : Assets > MyScript for UI > Inventory
// 이름 : InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool InventoryUIActive;

    private void Start()
    {
        Inventory.SetActive(false);
        InventoryUIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            InventoryUIActive = !InventoryUIActive;
            Inventory.SetActive(InventoryUIActive);
        }
        if (InventoryUIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}