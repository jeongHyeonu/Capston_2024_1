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



            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            //Destroy(other.gameObject);
            //Instantiate(fingerPrintPaperIron, spawnPoint, Quaternion.Euler(Vector3.zero));



            // 0505���� ������ ���� : ���� üũ�� ����
            GameObject fp_paper = Instantiate(fingerPrintPaperIron, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;

            //Destroy �Ʒ��� �̵�
            Destroy(other.gameObject);

        }

        if (other.gameObject.name == "flour_tape") // �������� �����϶�
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            //Destroy(other.gameObject);
            //Instantiate(fingerPrintPaperFlour, spawnPoint, Quaternion.Euler(Vector3.zero));



            // 0505���� ������ ���� : ���� üũ�� ����
            GameObject fp_paper = Instantiate(fingerPrintPaperFlour, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;

            //Destroy �Ʒ��� �̵�
            Destroy(other.gameObject);


        }

        if (other.gameObject.name == "red_tape") // ���� �������� �����϶�
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            //Destroy(other.gameObject);
            //Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));



            // 0505���� ������ ���� : ���� üũ�� ����
            GameObject fp_paper = Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;

            //Destroy �Ʒ��� �̵�
            Destroy(other.gameObject);
        }
    }
}
