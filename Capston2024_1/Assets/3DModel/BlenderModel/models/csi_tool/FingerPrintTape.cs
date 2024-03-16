using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���ֺ� ������ ������ ����
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape_soju; // ������
    [SerializeField] GameObject fingerPrintTape_knife; // ������

    [SerializeField] GameObject fingerPrintOnSoju; // ���ֺ� ���� �ִ� ����
    [SerializeField] GameObject fingerPrintOnKnife; // ��� ���� �ִ� ����  

    [SerializeField] GameObject rightHand; // ��������ġ
    [SerializeField] GameObject leftHand; // �޼���ġ

    [SerializeField] GameObject indicatorHand; // ux, ������ �� ���ٴ� ��� ǥ����
    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ

    [SerializeField] FingerPrintPaper fp_paper; // ������
    
    bool isTapeOnSoju = false;
    bool isTapeOnKnife = false;

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // ���ֺ� ���� �ִ� �����϶�
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintObject>().isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X

            // �ڷ�ƾ ����
            isTapeOnSoju = true;
            StartCoroutine(HandCheckCoroutine_soju());

            //ux
            indicatorHand.SetActive(true);
        }

        if (other.gameObject == fingerPrintOnKnife) // ��� ���� �ִ� �����϶�
        {
            if (fingerPrintOnKnife.GetComponent<FingerPrintObject>().isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X

            // �ڷ�ƾ ����
            isTapeOnKnife = true;
            StartCoroutine(HandCheckCoroutine_knife());

            //ux
            indicatorHand.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // ���ֺ� ���� �ִ� �����϶�
        {
            // �ڷ�ƾ �ߴ�
            isTapeOnSoju = false;
            StopCoroutine(HandCheckCoroutine_soju());

            //ux
            indicatorHand.SetActive(false);
        }

        if (other.gameObject == fingerPrintOnKnife) // ��� ���� �ִ� �����϶�
        {
            // �ڷ�ƾ �ߴ�
            isTapeOnKnife = false;
            StopCoroutine(HandCheckCoroutine_knife());

            //ux
            indicatorHand.SetActive(false);
        }
    }

    // �ð�(_time)���� ���� �ִ��� üũ�ϴ� �ڷ�ƾ - ����
    IEnumerator HandCheckCoroutine_soju(float _time = 0.2f)
    {
        if(isTapeOnSoju==false)
        {
            indicatorHand.SetActive(false);
            yield break; // ���ֿ� ������ �÷������� �ʴٸ� �ڷ�ƾ ���� �ߴ�
        }

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // �޼�-������ ��ġ üũ
        if (Vector3.Distance(indicatorHand.transform.position,leftHand.transform.position)<.08f) // �޼հ� ǥ���� ���� ������ �ִ°� �˻�
        {
            isTapeOnSoju = false;
            fp_paper.fingerPrintTape_soju = Instantiate(fingerPrintTape_soju, this.transform.position,Quaternion.Euler(new Vector3(0, 0, 0)));
            fingerPrintOnSoju.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // ����
            TutorialUX.Instance.NextHologram(4);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time ��ŭ �����ٰ�
        StartCoroutine(HandCheckCoroutine_soju()); // ��������� �ڷ�ƾ ����
    }

    // �ð�(_time)���� ���� �ִ��� üũ�ϴ� �ڷ�ƾ - ���
    IEnumerator HandCheckCoroutine_knife(float _time = 0.2f)
    {
        if (isTapeOnKnife == false)
        {
            indicatorHand.SetActive(false);
            yield break; // ��⿡ ������ �÷������� �ʴٸ� �ڷ�ƾ ���� �ߴ�
        }

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // �޼�-������ ��ġ üũ
        if (Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position) < .08f) // �޼հ� ǥ���� ���� ������ �ִ°� �˻�
        {
            isTapeOnKnife = false;
            fp_paper.fingerPrintTape_knife = Instantiate(fingerPrintTape_knife, this.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            fingerPrintOnKnife.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // ����
            TutorialUX.Instance.NextHologram(3);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time ��ŭ �����ٰ�
        StartCoroutine(HandCheckCoroutine_knife()); // ��������� �ڷ�ƾ ����
    }

    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        indicatorHand.SetActive(false);
    }
}
