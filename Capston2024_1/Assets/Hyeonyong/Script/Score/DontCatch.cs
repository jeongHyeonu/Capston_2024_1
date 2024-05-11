using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DontCatch : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI score;

    public void Catch()
    {
        score.text = "" + 0;
    }
}
