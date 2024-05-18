using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckActive : MonoBehaviour
{

    public GameObject EVi3;
    public GameObject EVi4;

    public TextMeshProUGUI Score3;
    public TextMeshProUGUI Score4;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveCheck()
    {
        if (EVi3.activeSelf == false)
        {
            Score3.text = "" + 0;
        }
        if (EVi4.activeSelf == false)
        {
            Score4.text = "" + 0;
        }
    }
}
