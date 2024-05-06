using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class TagChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Near")
        {
            Debug.Log("º¯°æ");
            gameObject.tag= other.name+"finger";
        }
    }
}
