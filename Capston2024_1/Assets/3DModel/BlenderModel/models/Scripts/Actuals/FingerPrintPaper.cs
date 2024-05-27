using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 지문채취 전사지에 부여할 스크립트 - 지문 감식 테이프 올려놓으면 수행
public class FingerPrintPaper : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintPaperIron; // 프리팹
    [SerializeField] GameObject fingerPrintPaperFlour; // 프리팹
    [SerializeField] GameObject fingerPrintPaperRed; // 프리팹

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "iron_tape") // 철가루 지문일때
        {
            other.GetComponent<Collider>().enabled = false; // 더이상 테이프 반응 안하게
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperIron, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - 정현우
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // 사운드
            Destroy(this.gameObject); // 기존 전사지 파괴
        }

        if (other.gameObject.name == "flour_tape") // 형광가루 지문일때
        {
            other.GetComponent<Collider>().enabled = false; // 더이상 테이프 반응 안하게
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperFlour, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - 정현우
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // 사운드
            Destroy(this.gameObject); // 기존 전사지 파괴
        }

        if (other.gameObject.name == "red_tape") // 적색 형광가루 지문일때
        {
            other.GetComponent<Collider>().enabled = false; // 더이상 테이프 반응 안하게
            Vector3 spawnPoint = this.transform.position + new Vector3(0, .02f, 0);
            GameObject fp_paper = Instantiate(fingerPrintPaperRed, spawnPoint, Quaternion.Euler(Vector3.zero));
            fp_paper.name = other.GetComponent<SubName>().subName;
            Destroy(other.gameObject);

            // 0512 - 정현우
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.BOTTLECAP_8); // 사운드
            Destroy(this.gameObject); // 기존 전사지 파괴
        }
    }
}
