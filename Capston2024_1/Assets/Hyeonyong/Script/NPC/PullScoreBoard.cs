using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullScoreBoard : MonoBehaviour
{

    public GameObject CheckButton;
    public GameObject ScoreBoard;


    public Vector3 ScoreBoard_firstPos;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard_firstPos = ScoreBoard.transform.position;
        ScoreBoard.transform.position += new Vector3(0f, 100f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pull() { 

        ScoreBoard.transform .position = ScoreBoard_firstPos;
        CheckButton.SetActive(false);
    }
}
