using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���� ���� ������ �÷������� ����
public class FingerPrintPaper_tutorial : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintPaperBlack; // ������
    [SerializeField] GameObject fingerPrintPaperUV; // ������
    [SerializeField] GameObject fingerPrintPaperRed; // ������

    [SerializeField] public GameObject fingerPrintTape_soju; // ���ֺ� ���� �ִ� ����
    [SerializeField] public GameObject fingerPrintTape_knife; // ��� ���� �ִ� ����  
    [SerializeField] public GameObject fingerPrintTape_red;

    [SerializeField] public GameObject lastTutoBoard;
    [SerializeField] public GameObject tutoCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintTape_soju) // ���ֺ� ���� �ִ� �����϶�
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .05f, 0);
            TutorialUX.Instance.hologramObjects[4].SetActive(false);
            lastTutoBoard?.SetActive(true);
            tutoCam?.GetComponent<TutorialCamera>().lastStep_ON();
            Destroy(fingerPrintTape_soju);

            // Ʃ�丮�� - ������ ����Բ�
            GameObject fp_paper = Instantiate(fingerPrintPaperBlack, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.GetComponent<Grabbable>().enabled = false;
            fp_paper.GetComponent<GrabInteractable>().enabled = false;
        }

        if (other.gameObject == fingerPrintTape_knife) // ��� ���� �ִ� �����϶�
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            Destroy(fingerPrintTape_knife);
            Instantiate(fingerPrintPaperUV, spawnPoint, Quaternion.Euler(Vector3.zero));
        }

        if (other.gameObject == fingerPrintTape_red) // ���������϶�
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            Destroy(fingerPrintTape_red);
            Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));
        }
    }
}
