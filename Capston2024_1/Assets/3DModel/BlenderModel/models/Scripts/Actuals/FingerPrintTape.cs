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
    public string name;


    public bool onLab=false;
    private void Start() // ���� ��ü �����ߴ� ��ġ ���
    {
        originPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FingerPrintObject>(out var fp_obj))
        {
            if (fp_obj.isVisible == false) return; // ������ ���� �巯���� �ʾҴٸ� ����X


            if (onLab == true)
            {
                fp_obj.transform.position = new Vector3(fp_obj.transform.position.x, fp_obj.transform.position.y + 0.05f, fp_obj.transform.position.z);
            }
            //ö���� ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.iron)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_iron, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "iron_tape";
            }

            //�������� ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.flour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_flour, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "flour_tape";
            }

            //������������ ������ �������� ä���� ���
            if (fp_obj.obj_type == FingerPrintObject.ObjectType.redFlour)
            {
                GameObject fp_tape = Instantiate(fingerPrintTapePrefab_red, fp_obj.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                fp_tape.name = "red_tape";
            }

            fp_obj.gameObject.SetActive(false);
            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.TAPE); // ����

            ////////////////////////////////0505���� ������ �߰� : ���޽�����
            onTape = true;
            //////////////////////////////
        }


    }

    // ���� ��ġ�� �̵�
    public void MoveOriginPos()
    {
        this.transform.position = originPos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
