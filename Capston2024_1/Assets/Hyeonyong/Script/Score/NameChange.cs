using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameChange : MonoBehaviour
{
    // Start is called before the first frame update

    public string onName;

    public bool onChanged = false;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "iron_tape"|| other.name == "flour_tape" || other.name == "red_tape" &&onChanged==false)
        {
            Debug.Log("����");
            other.GetComponent<SubName>().subName = onName; //���� �������� ����
            onChanged = true;

            //Destroy(gameObject);
            this.gameObject.transform.position += new Vector3(0f, 1000f, 0f);
        }
    }

    
    public void OnTriggerStay(Collider other)
    {
        if (other.name == "iron_tape" || other.name == "flour_tape" || other.name == "red_tape" && onChanged == false)
        {
            Debug.Log("����");
            other.GetComponent<SubName>().subName = onName; //���� �������� ����
            onChanged = true;

            this.gameObject.transform.position += new Vector3(0f, 1000f, 0f);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name == "iron_tape" || other.name == "flour_tape" || other.name == "red_tape" && onChanged == false)
        {
            Debug.Log("����");
            other.GetComponent<SubName>().subName = onName; //���� �������� ����
            onChanged = true;

            // Destroy(this.gameObject);
            this.gameObject.transform.position += new Vector3(0f, 1000f, 0f);
        }
    }
    
}
