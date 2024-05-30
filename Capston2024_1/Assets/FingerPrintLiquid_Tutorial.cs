using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPrintLiquid_Tutorial : MonoBehaviour
{
    private bool paperTriggered = false; // Paper���� �浹�� �����ϱ� ���� ����
    private bool hairLiquidTriggered = false; // Iron_Liquid���� �浹�� �����ϱ� ���� ����
    private bool liquidTriggered = false; // Liquid���� �浹�� �����ϱ� ���� ����

    [SerializeField] TutorialUX_Liquid t_ux;
    [SerializeField] TutorialCamera_Liquid tutoCam;
    [SerializeField] GameObject paper;

    [SerializeField] public int maxDryCnt = 10;
    int dryCnt = 0;

    static bool isTutorialUX = false;

    // Paper�� Iron_Liquid�� �浹�� �����ϴ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            //SoundManager.Instance.PlaySFX(SoundManager.SFX_list.WOOSH_1);
            paperTriggered = true; // Paper���� �浹�� �߻������� ǥ��
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Hair"))
        {
            hairLiquidTriggered = true; // Iron_Liquid���� �浹�� �߻������� ǥ��
        }
        else if (other.gameObject.CompareTag("Liquid"))
        {
            liquidTriggered = true; // Liquid���� �浹�� �߻������� ǥ��
        }

        CheckTriggered(); // �浹�� üũ�Ͽ� ���� ���� ����
    }

    // Paper�� Iron_Liquid ��� �浹�ߴ��� Ȯ���Ͽ� ���� ���� �����ϴ� �޼���
    private void CheckTriggered()
    {
        // Paper�� Iron_Liquid ��� �浹�� ���
        if (paperTriggered && hairLiquidTriggered && liquidTriggered)
        {
            StartCoroutine(TriggerEffect()); // ���� ������ ���� �ڷ�ƾ ����
        }
    }

    // ���̵� �� ȿ���� �����ϴ� �ڷ�ƾ �޼���
    private IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(maxDryCnt-1f);

        this.transform.gameObject.GetComponent<MeshRenderer>().materials[0].DOFade(1f, 0f);

        if (!isTutorialUX)
        {
            isTutorialUX = true;
            t_ux.TutorialStep(4);
            tutoCam.secondStep_ON();
            paper.transform.DOMove(paper.transform.position + new Vector3(0, 0, .3f), 2f).SetDelay(1f);
        }
    }
}
