using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public GameObject EvidenceObj;

    //public GameObject Ev1_IDCard;  // ���Ź�1 object
    public GameObject Ev1_IDCard_PackedObj; // ������ ���Ź�1 object

    //public GameObject Ev2_Soju;  // ���Ź�1 object
    public GameObject Ev2_Soju_PackedObj; // ������ ���Ź�1 object



    //public GameObject Box;      // ���Ź� ����
    //public GameObject PaperBag; // ���Ź� ����
    //public GameObject ZipLock;  // ���Ź� ���۹�

    public static bool Ev1_IDCard_isPacked = false;
    public static bool Ev2_Soju_isPacked = false;

    // ���Ź� ���� Ȯ��&���� �Լ�
    public void CategorizeEvidence()
    {
        //layer�� Ȯ��
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
    //Y��ư ������ �����Ǵ� �Լ�
    public void CollectEvidence()
    {
        //CategorizeEvidence();

        //��Ʈ�ѷ� Y��ư ������ WristUI Ȱ��/��Ȱ��
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
