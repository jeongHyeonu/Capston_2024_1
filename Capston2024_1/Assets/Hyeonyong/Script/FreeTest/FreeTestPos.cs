using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTestPos : MonoBehaviour
{
    public GameObject testPos1;
    public GameObject testPos2;
    public GameObject hand;
    private npcText npctext;
    public bool find = false;

    public GameObject NP;
    private NearPlayer nearplayer;
    private bool near=false;

    // Start is called before the first frame update

    private void Start()
    {
        nearplayer=NP.GetComponent<NearPlayer>();
        npctext = hand.GetComponent<npcText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        near = nearplayer.near;
        if (other.gameObject.layer == LayerMask.NameToLayer("UV_Light") && find == false && near==true)
        {
            if (testPos1 != null)
            {
                testPos1.SetActive(true);
            }
            if (testPos2 != null)
            {
                testPos2.SetActive(true);
            }
           // npctext.FindFingerPrint();
            find= true;
        }
    }
}
