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
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.name == "iron_tape" || other.name == "flour_tape" || other.name == "red_tape" && onChanged == false)
        {
            Debug.Log("����");
            other.GetComponent<SubName>().subName = onName; //���� �������� ����
            onChanged = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name == "iron_tape" || other.name == "flour_tape" || other.name == "red_tape" && onChanged == false)
        {
            Debug.Log("����");
            other.GetComponent<SubName>().subName = onName; //���� �������� ����
            onChanged = true;
        }
    }
}
