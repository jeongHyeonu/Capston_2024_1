using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLight : MonoBehaviour
{
    public bool onLight = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
            onLight = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
            onLight = false;
    }
}
