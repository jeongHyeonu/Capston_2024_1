using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFlashLightClicked : MonoBehaviour
{

    public GameObject FlashLight;
    public GameObject FlashLightPos;

    public static bool FlashLightActive; //FlashLightActive Ȱ�� ���� ����


    //
    public void TransformFlashLight()
    {
        FlashLight.transform.position = FlashLightPos.transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        TransformFlashLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
