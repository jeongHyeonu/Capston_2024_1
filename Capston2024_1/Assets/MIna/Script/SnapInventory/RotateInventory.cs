using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInventory : MonoBehaviour
{
    public GameObject Inventory;
    
    public void Rotate()
    {
        Inventory.transform.Rotate(new Vector3(0, 180.0f, 0));
    }


    void Update()
    {
        
    }


}
