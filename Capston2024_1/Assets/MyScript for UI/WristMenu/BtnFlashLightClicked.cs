using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFlashLightClicked : MonoBehaviour
{

    public GameObject FlashLight;
    public GameObject FlashLightPos;
    public GameObject OutsideFlashLightPos;

    public static bool FlashLightActive; //FlashLightActive 활성 상태 유무


    // inside map
    public void InTransFlashLight()
    {
        FlashLight.transform.position = FlashLightPos.transform.position;
        FlashLight.transform.rotation = FlashLightPos.transform.rotation;
        FlashLightActive = true;
    }

    //outside map
    public void OutTransFlashLight()
    {
        FlashLight.transform.position = OutsideFlashLightPos.transform.position;
        FlashLightActive = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        OutTransFlashLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
