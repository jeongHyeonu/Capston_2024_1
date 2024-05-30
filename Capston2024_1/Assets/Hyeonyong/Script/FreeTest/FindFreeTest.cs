using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFreeTest : MonoBehaviour
{
    public GameObject testPos;
    public bool find = false;


    public  GameObject NP;
    private NearPlayer nearplayer;
    private bool near = false;
    // Start is called before the first frame update


    private FingerPrintObject FPT;
    private void Start()
    {
        nearplayer = NP.GetComponent<NearPlayer>();
        FPT = GetComponent<FingerPrintObject>();
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        near = nearplayer.near;
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light") && find == false &&near==true)
        {
            if (testPos != null)
            {
                testPos.SetActive(false);
            }
        }
    }*/

    private void Update()
    {
        if (this.FPT.isVisible == true)
        {
            if (testPos != null)
            {
                testPos.SetActive(false);
            }
        }
        
    }
}
