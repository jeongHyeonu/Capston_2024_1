using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testcs : MonoBehaviour
{
    public FingerPrintObject fingerprintobject;



    //0527 양현용 추가
    public FingerPrintObject_tutorial ft;
    public GameObject FingerPrint;
    public bool onTutorial = false;

    private void Start()
    {
        if (onTutorial == false)
        {
            fingerprintobject = GetComponent<FingerPrintObject>();
        }
        if (onTutorial == true) { 
            ft=FingerPrint.GetComponent<FingerPrintObject_tutorial>();       
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (onTutorial == false)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
                this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
        }
        if (onTutorial == true)
        {
            if (ft.isVisible == false)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
                    this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0.4f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (onTutorial == false)
        {
            if (fingerprintobject.isVisible == false)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
                    this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(0f, 0.4f);
            }
        }

        if(onTutorial == true)
        {
            if (ft.isVisible == false)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light"))
                    this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(0f, 0.4f);
            }
        }
    }

}
