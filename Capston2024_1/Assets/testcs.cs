using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testcs : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
            this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
            this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(0f, 0.4f);
    }

}
