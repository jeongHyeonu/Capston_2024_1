using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapItem : MonoBehaviour
{
    public GameObject SnapPos;
    public GameObject Inventory;
    public bool isSnapped;
    private bool isItemSnapped;

    private bool isGrabbed;



    // Update is called once per frame
    void Update()
    {
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        isItemSnapped = SnapPos.GetComponent<SnapLoaction>().Snapped;

        if(isItemSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(Inventory.transform);
            isSnapped = true;
        }

        if(isItemSnapped == false && isGrabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
