using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���� ���� ������ �÷������� ����
public class FingerPrintPaper : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintPaperIron; // ������
    [SerializeField] GameObject fingerPrintPaperFlour; // ������
    [SerializeField] GameObject fingerPrintPaperRed; // ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "iron_tape") // ö���� �����϶�
        {
            other.GetComponent<Collider>().enabled = false; // ���̻� ������ ���� ���ϰ�
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperIron, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - ������
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // ����
            Destroy(this.gameObject); // ���� ������ �ı�
        }

        if (other.gameObject.name == "flour_tape") // �������� �����϶�
        {
            other.GetComponent<Collider>().enabled = false; // ���̻� ������ ���� ���ϰ�
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperFlour, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - ������
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // ����
            Destroy(this.gameObject); // ���� ������ �ı�
        }

        if (other.gameObject.name == "red_tape") // ���� �������� �����϶�
        {
            other.GetComponent<Collider>().enabled = false; // ���̻� ������ ���� ���ϰ�
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - ������
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // ����
            Destroy(this.gameObject); // ���� ������ �ı�
        }
    }
}
