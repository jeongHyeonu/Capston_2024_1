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

    public GameObject CenterEyeObj;  // ��ŧ���� CameraRig�� CenterEyeObj ����
    OVRScreenFade OFade;

    public void SceneFade()
    {
        Debug.Log("�� �̵� ����");
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
