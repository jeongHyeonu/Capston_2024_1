using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testcs : MonoBehaviour
{
    public FingerPrintObject fingerprintobject;

    private void Start()
    {
        fingerprintobject = GetComponent<FingerPrintObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
            this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (fingerprintobject.isVisible == false) {
            if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
                this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(0f, 0.4f);
        }
    }

}
