using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public GameObject EvidenceObj;

    //public GameObject Ev1_IDCard;  // 증거물1 object
    public GameObject Ev1_IDCard_PackedObj; // 수집된 증거물1 object

    //public GameObject Ev2_Soju;  // 증거물1 object
    public GameObject Ev2_Soju_PackedObj; // 수집된 증거물1 object



    //public GameObject Box;      // 증거물 상자
    //public GameObject PaperBag; // 증거물 봉투
    //public GameObject ZipLock;  // 증거물 지퍼백

    public static bool Ev1_IDCard_isPacked = false;
    public static bool Ev2_Soju_isPacked = false;

    // 증거물 종류 확인&수집 함수
    public void CategorizeEvidence()
    {
        //layer로 확인
        if(EvidenceObj.layer == LayerMask.NameToLayer("Ev1_IDCard"))
        {
            Ev1_IDCard_isPacked = true;
        }
        else if(EvidenceObj.layer == LayerMask.NameToLayer("Ev2_Soju"))
        {
            Ev2_Soju_isPacked = true;
        }
    }
    
    /*
    //Y버튼 누르면 수집되는 함수
    public void CollectEvidence()
    {
        //CategorizeEvidence();

        //컨트롤러 Y버튼 누르면 WristUI 활성/비활성
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if(Ev1_IDCard_PackedObj == true)
            {
                Ev1_IDCard_PackedObj.transform.position = EvidenceObj.transform.position;
                Ev1_IDCard_PackedObj.transform.rotation = EvidenceObj.transform.rotation;

                EvidenceObj.SetActive(false);
                Ev1_IDCard_PackedObj.SetActive(true);
            }

            if (Ev2_Soju_PackedObj == true)
            {
                Ev2_Soju_PackedObj.transform.position = EvidenceObj.transform.position;
                Ev2_Soju_PackedObj.transform.rotation = EvidenceObj.transform.rotation;

                EvidenceObj.SetActive(false);
                Ev2_Soju_PackedObj.SetActive(true);
            }



        }
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CollectEvidence();
    }
}
