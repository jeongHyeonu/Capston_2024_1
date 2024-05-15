using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningBrushHead : MonoBehaviour
{
    int maxText1 = 18; // �ؽ�Ʈ1 ���ڼ�
    int maxText2 = 17; // �ؽ�Ʈ2 ���ڼ�

    [SerializeField] int countText1 = 0;
    [SerializeField] int countText2 = 0;

    [SerializeField] GameObject uxObject1_brush, uxObject1_tape, text2, uxObject2_brush, uxObject2_tape, playButton;
    [SerializeField] ParticleSystem particles;

    Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    Quaternion originRot; // ���� ����

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
        originRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "printText1")
        {
            other.GetComponent<BoxCollider>().enabled = false;
            countText1++;
            if(countText1 == 3) { uxObject1_brush.SetActive(false); uxObject1_tape.SetActive(false); }
            else if(countText1 == maxText1) { uxObject2_brush.SetActive(true); uxObject2_tape.SetActive(true); text2.SetActive(true); }
            other.GetComponent<MeshRenderer>().material.DOFade(1f,.5f);
            particles.Play();
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.SPRAY);
        }
        else if(other.name == "printText2")
        {
            other.GetComponent<BoxCollider>().enabled = false;
            countText2++;
            if (countText2 == 3) { uxObject2_brush.SetActive(false); uxObject2_tape.SetActive(false); }
            else if (countText2 == maxText2) playButton.SetActive(true);
            other.GetComponent<MeshRenderer>().material.DOFade(1f, .5f);
            particles.Play();
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.SPRAY);
        }
    }

    // ���� ��ġ�� �̵�
    public void SetOrigin()
    {
        this.transform.position = originPos;
        this.transform.rotation = originRot;
    }

    // ���̵�
    public void moveScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
