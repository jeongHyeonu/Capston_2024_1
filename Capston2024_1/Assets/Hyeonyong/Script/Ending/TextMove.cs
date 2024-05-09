using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Rendering;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
