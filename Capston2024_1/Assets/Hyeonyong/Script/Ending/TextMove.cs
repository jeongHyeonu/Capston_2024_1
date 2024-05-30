using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMove : MonoBehaviour
{
    public float Speed = 1f;

    //public GameObject CenterEyeObj;  // ��ŧ���� CameraRig�� CenterEyeObj ����
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
