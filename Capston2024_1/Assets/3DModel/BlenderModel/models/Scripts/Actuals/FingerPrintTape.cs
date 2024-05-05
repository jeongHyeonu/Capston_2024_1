using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ä�� �������� �ο��� ��ũ��Ʈ - ���ֺ� ������ ������ ����
public class FingerPrintTape : MonoBehaviour
{
    [SerializeField] GameObject fingerPrintTapePrefab_iron; // ö���� ���� ������ ������
    [SerializeField] GameObject fingerPrintTapePrefab_flour; // �������� ���� ������ ������
    [SerializeField] GameObject fingerPrintTapePrefab_red; // ������������ ���� ������ ������

    [SerializeField] Vector3 originPos; // ���� ��ü �����ߴ� ��ġ
    [SerializeField] FingerPrintPaper fp_paper; // ������


    public bool onTape = false; //0426�� ������ : ������ ���� �Ǵܿ����� �߰�
    

    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FingerPrintObject>(out var fp_obj))
        {
            if (fp_obj.isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X

            //ö���� ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.iron)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_iron, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fp_tape.name = "iron_tape";
            }

            //�������� ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.flour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_flour, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fp_tape.name = "flour_tape";
            }

            //������������ ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.redFlour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_red, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fp_tape.name = "red_tape";
            }

            fp_obj.gameObject.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // ����
        }

    }

    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
