using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 전사지에 부여할 스크립트 - 지문 감식 테이프 올려놓으면 수행
public class FingerPrintPaper_tutorial : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintPaperBlack; // 프리팹
    [SerializeField] GameObject fingerPrintPaperUV; // 프리팹
    [SerializeField] GameObject fingerPrintPaperRed; // 프리팹

    [SerializeField] public GameObject fingerPrintTape_soju; // 소주병 위에 있는 지문
    [SerializeField] public GameObject fingerPrintTape_knife; // 흉기 위에 있는 지문  
    [SerializeField] public GameObject fingerPrintTape_red;

    [SerializeField] public GameObject lastTutoBoard;
    [SerializeField] public GameObject tutoCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintTape_soju) // 소주병 위에 있는 지문일때
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .05f, 0);
            TutorialUX.Instance.hologramObjects[4].SetActive(false);
            lastTutoBoard?.SetActive(true);
            tutoCam?.GetComponent<TutorialCamera>().lastStep_ON();
            Destroy(fingerPrintTape_soju);

            // 튜토리얼 - 전사지 못잡게끔
            GameObject fp_paper = Instantiate(fingerPrintPaperBlack, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.GetComponent<Grabbable>().enabled = false;
            fp_paper.GetComponent<GrabInteractable>().enabled = false;
        }

        if (other.gameObject == fingerPrintTape_knife) // 흉기 위에 있는 지문일때
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            Destroy(fingerPrintTape_knife);
            Instantiate(fingerPrintPaperUV, spawnPoint, Quaternion.Euler(Vector3.zero));
        }

        if (other.gameObject == fingerPrintTape_red) // 적색지문일때
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            Destroy(fingerPrintTape_red);
            Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));
        }
    }
}
