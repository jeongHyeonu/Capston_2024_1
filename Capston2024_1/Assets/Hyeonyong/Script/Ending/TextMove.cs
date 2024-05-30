using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMove : MonoBehaviour
{
    public float Speed = 1f;

    //public GameObject CenterEyeObj;  // 오큘러스 CameraRig의 CenterEyeObj 연결
    //OVRScreenFade OFade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneFadeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    IEnumerator SceneFadeCoroutine()
    {
        //OFade.FadeOut();
        yield return new WaitForSeconds(30f);
        //yield return new WaitForSeconds(OFade.fadeTime);

        SceneManager.LoadScene("Opening");
    }
}
