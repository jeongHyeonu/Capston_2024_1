using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEvidence : MonoBehaviour
{
    public GameObject Ev1_Pos;
    public GameObject Ev2_Pos;
    public GameObject Ev3_Pos;
    public GameObject Ev4_Pos;
    public GameObject Ev_Pos;


    // Start is called before the first frame update
    void Start()
    {
        Ev1_Pos.SetActive(false);
        Ev2_Pos.SetActive(false);
        Ev3_Pos.SetActive(false);
        Ev4_Pos.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckEvidence.Ev1_isChecked == true)
        {
            Ev1_Pos.SetActive(true);
        }

        if (CheckEvidence.Ev2_isChecked == true)
        {
            Ev2_Pos.SetActive(true);
        }

        if (CheckEvidence.Ev3_isChecked == true)
        {
            Ev3_Pos.SetActive(true);
        }

        if (CheckEvidence.Ev4_isChecked == true)
        {
            Ev4_Pos.SetActive(true);
        }
    }
}
