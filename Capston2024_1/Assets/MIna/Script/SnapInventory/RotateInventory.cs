using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInventory : MonoBehaviour
{
    public GameObject Inventory;
    
    public void ToolsRotateR()
    {
        Inventory.transform.Rotate(new Vector3(0, 90.0f, 0));
    }

    public void ToolsRotateL()
    {
        Inventory.transform.Rotate(new Vector3(0, -90.0f, 0));
    }
    public void EvidenceRotateL()
    {
        Inventory.transform.Rotate(new Vector3(0, -90.0f, 0));
    }
    public void EvidenceRotateR()
    {
        Inventory.transform.Rotate(new Vector3(0, +90.0f, 0));
    }
    

    void Update()
    {
        
    }


}
