using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartBtn : MonoBehaviour
{
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
        OFade.FadeOut();

        yield return new WaitForSeconds(OFade.fadeTime);

        SceneManager.LoadScene("Opening");
    }
}
