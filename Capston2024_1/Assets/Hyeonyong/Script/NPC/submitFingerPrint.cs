using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class submitFingerPrint : MonoBehaviour
{
    CheckCard checkcard;
    public GameObject HandTrigger;
    npcText failed;

    public TextMeshPro thirdCameraScore1;

    public bool isfreeTest = false;
    // Start is called before the first frame update
    void Start()
    {
        failed = HandTrigger.GetComponent<npcText>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("npc�� ��Ҵ�.");
        if (other.tag=="FINGERPRINTCARD")
        {
            checkcard=other.GetComponent<CheckCard>();
            if (checkcard.onCheckCard == true)
            {
                Debug.Log("npc�� ���⼺��.");
                thirdCameraScore1.text = "15";
                Destroy(other.gameObject);
            }
            else if(checkcard.onCheckCard == false)
            {
                Debug.Log("npc�� ���������� 3��° �Կ� ����.");
                Destroy(other.gameObject);
                failed.FailedThirdCamera();
            }
        }
    }
}
