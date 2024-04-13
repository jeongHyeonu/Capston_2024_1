using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public GameObject obj;

    // Update is called once per frame
    void Update()
    {
        Vector3 newVector = new Vector3(obj.transform.position.x, transform.position.y, obj.transform.position.z);
        this.transform.LookAt(newVector);
    }
}
