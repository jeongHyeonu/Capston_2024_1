using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoBoard : MonoBehaviour
{
    [SerializeField] GameObject targetBoard;

    private void OnEnable()
    {
        targetBoard.SetActive(true);
        enabled = false;
    }
}
