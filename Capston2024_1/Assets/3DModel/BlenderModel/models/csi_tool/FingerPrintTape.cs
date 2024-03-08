using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���ֺ� ������ ������ ����
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTape;
    [SerializeField] GameObject fingerPrintOnSoju; // ���ֺ� ���� �ִ� ����

    [SerializeField] GameObject rightHand; // ��������ġ
    [SerializeField] GameObject leftHand; // �޼���ġ

    [SerializeField] GameObject indicatorHand; // ux, ������ �� ���ٴ� ��� ǥ����
    [SerializeField] GameObject originPos; // ���� ��ü �����ߴ� ��ġ

    bool isTapeOnSoju = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintOnSoju) // ���ֺ� ���� �ִ� �����϶�
        {
            if (fingerPrintOnSoju.GetComponent<FingerPrintSoju>().isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X

            // �ڷ�ƾ ����
            isTapeOnSoju = true;
            StartCoroutine(HandCheckCoroutine());
            // Instantiate(fingerPrintTape,this.transform.position,Quaternion.Euler(Vector3.zero));
            // other.gameObject.SetActive(false);

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
            StopCoroutine(HandCheckCoroutine());

            //ux
            indicatorHand.SetActive(false);
        }
    }

    // �ð�(_time)���� ���� �ִ��� üũ�ϴ� �ڷ�ƾ
    IEnumerator HandCheckCoroutine(float _time = 0.2f)
    {
        if(isTapeOnSoju==false) yield break; // ���ֿ� ������ �÷������� �ʴٸ� �ڷ�ƾ ���� �ߴ�

        //Debug.Log(Vector3.Distance(indicatorHand.transform.position, leftHand.transform.position));
        // �޼�-������ ��ġ üũ
        if (Vector3.Distance(indicatorHand.transform.position,leftHand.transform.position)<.05f) // �޼հ� ǥ���� ���� ������ �ִ°� �˻�
        {
            isTapeOnSoju = false;
            Instantiate(fingerPrintTape,this.transform.position,Quaternion.Euler(Vector3.zero));
            fingerPrintOnSoju.SetActive(false);

            //ux
            indicatorHand.SetActive(false);
        }

        yield return new WaitForSeconds(_time); // _time ��ŭ �����ٰ�
        StartCoroutine(HandCheckCoroutine()); // ��������� �ڷ�ƾ ����
    }

    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos.transform.position;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
