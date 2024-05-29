using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지문채취 테이프에 부여할 스크립트 - 소주병 지문에 닿으면 실행
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTapePrefab_iron; // 철가루 지문 테이프 프리팹
    [SerializeField] GameObject fingerPrintTapePrefab_flour; // 형광가루 지문 테이프 프리팹
    [SerializeField] GameObject fingerPrintTapePrefab_red; // 적색형광가루 지문 테이프 프리팹

    [SerializeField] Vector3 originPos; // 원래 물체 존재했던 위치
    [SerializeField] FingerPrintPaper fp_paper; // 전사지


    public bool onTape = false; //0426자 양현용 : 테이프 생성 판단용으로 추가
    public string name;


    public bool onLab=false;
    private void Start() // 원래 물체 존재했던 위치 기억
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FingerPrintObject>(out var fp_obj))
        {
            if (fp_obj.isVisible == false) return; // 지문이 아직 드러나지 않았다면 실행X


            if (onLab == true)
            {
                fp_obj.transform.position = new Vector3(fp_obj.transform.position.x, fp_obj.transform.position.y + 0.05f, fp_obj.transform.position.z);
            }
            //철가루 지문을 테이프로 채취한 경우
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.iron)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_iron, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "iron_tape";
            }

            //형광가루 지문을 테이프로 채취한 경우
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.flour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_flour, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "flour_tape";
            }

            //적색형광가루 지문을 테이프로 채취한 경우
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.redFlour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_red, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "red_tape";
            }

            fp_obj.gameObject.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // 사운드

            ////////////////////////////////0505일자 양현용 추가 : 경고메시지용
            onTape = true;
            //////////////////////////////
        }


    }

    // 원래 위치로 이동
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
