using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartBtn : MonoBehaviour
{
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
        OFade.FadeOut();

        yield return new WaitForSeconds(OFade.fadeTime);

        SceneManager.LoadScene("Opening");
    }
}
