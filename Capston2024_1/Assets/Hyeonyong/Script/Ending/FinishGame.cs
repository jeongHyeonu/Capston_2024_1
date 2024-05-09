using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneFade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CenterEyeObj;  // 오큘러스 CameraRig의 CenterEyeObj 연결
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("씬 이동 시작");
        OFade = CenterEyeObj.transform.GetComponent<OVRScreenFade>();
        StartCoroutine(SceneFadeCoroutine());
    }
    IEnumerator SceneFadeCoroutine()
    {

        yield return new WaitForSeconds(15f);

        OFade.FadeOut();

        yield return new WaitForSeconds(OFade.fadeTime);

        //SceneManager.LoadScene("Lab_Hyeonyong");
        SceneManager.LoadScene("Opening");
    }
}
