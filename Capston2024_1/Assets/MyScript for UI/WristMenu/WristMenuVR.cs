using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WristMenuVR : MonoBehaviour
{

    public GameObject WristMenu;
    public GameObject Anchor;
    bool WristMenuUIActive;

    private void Start()
    {
        WristMenu.SetActive(false);
        WristMenuUIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            WristMenuUIActive = !WristMenuUIActive;
            WristMenu.SetActive(WristMenuUIActive);
        }
        if (WristMenuUIActive)
        {
            WristMenu.transform.position = Anchor.transform.position;
            WristMenu.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}
