using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���ֺ� ������ ������ ����
public class FingerPrintTape_tutorial : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape_soju; // ������
    [SerializeField] GameObject fingerPrintTape_knife; // ������

    [SerializeField] GameObject fingerPrintOnSoju; // ���ֺ� ���� �ִ� ����
    [SerializeField] GameObject fingerPrintOnKnife; // ��� ���� �ִ� ����  

    [SerializeField] GameObject rightHand; // ��������ġ
    [SerializeField] GameObject leftHand; // �޼���ġ

    [SerializeField] GameObject indicatorHand; // ux, ������ �� ���ٴ� ��� ǥ����
    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ

    [SerializeField] FingerPrintPaper_tutorial fp_paper; // ������


    public bool onTape = false; //0426�� ������ : ������ ���� �Ǵܿ����� �߰�
    

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // ���ֺ� ���� �ִ� �����϶�
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintObject_tutorial>().isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X

            fp_paper.fingerPrintTape_soju = Instantiate(fingerPrintTape_soju, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            fingerPrintOnSoju.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // ����
            TutorialUX.Instance.NextHologram(4);
        }
    }


    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        indicatorHand.SetActive(false);
    }
}
