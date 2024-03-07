using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "fingerPrint2_fingerPrint")
        {
            Instantiate(fingerPrintTape,this.transform.position,Quaternion.Euler(Vector3.zero));
            other.gameObject.SetActive(false);
        }
        
    }
}
