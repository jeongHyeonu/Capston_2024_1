using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 전사지에 부여할 스크립트 - 지문 감식 테이프 올려놓으면 수행
public class FingerPrintPaper : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintPaperBlack; // 프리팹
    [SerializeField] GameObject fingerPrintPaperUV; // 프리팹

    [SerializeField] public GameObject fingerPrintTape_soju; // 소주병 위에 있는 지문
    [SerializeField] public GameObject fingerPrintTape_knife; // 흉기 위에 있는 지문  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fingerPrintTape_soju) // 소주병 위에 있는 지문일때
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            TutorialUX.Instance.hologramObjects[4].SetActive(false);
            Destroy(fingerPrintTape_soju);
            Instantiate(fingerPrintPaperBlack, spawnPoint, Quaternion.Euler(Vector3.zero));
        }

        if (other.gameObject == fingerPrintTape_knife) // 흉기 위에 있는 지문일때
        {
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .01f, 0);
            Destroy(fingerPrintTape_knife);
            Instantiate(fingerPrintPaperUV, spawnPoint, Quaternion.Euler(Vector3.zero));
        }
    }
}
