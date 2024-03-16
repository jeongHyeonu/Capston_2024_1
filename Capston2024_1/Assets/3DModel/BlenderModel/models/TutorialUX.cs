using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUX : Singleton<TutorialUX>
{
    public int stepCount = 0;

    [SerializeField] GameObject gripUX;
    [SerializeField] GameObject triggerUX;

    GameObject createdUX;

    [SerializeField] bool isTutorial;

    [SerializeField] public List<GameObject> hologramObjects;

    public void GripUX_ON(GameObject obj)
    {
        if (!createdUX) Destroy(createdUX);
        Vector3 objPos = obj.transform.position + new Vector3(0, .15f, .2f);
        createdUX = Instantiate(gripUX, objPos, Quaternion.Euler(Vector3.zero));
    }

    public void TriggerUX_ON(GameObject obj)
    {
        if(!createdUX)  Destroy(createdUX);
        Vector3 objPos = obj.transform.position + new Vector3(0, .15f, .2f);
        createdUX = Instantiate(triggerUX, objPos, Quaternion.Euler(Vector3.zero));
    }

    public void UX_OFF()
    {
        Destroy(createdUX);
    }

    int idx = 0;
    public void NextHologram(int stepIdx)
    {
        if (stepIdx < stepCount) return;
        if (!isTutorial) return; // 튜토리얼 아니면 실행X
        stepCount++;
        hologramObjects[idx++].SetActive(false);
        hologramObjects[idx].SetActive(true);
    }

    public void SojuHologramOFF() { hologramObjects[2].transform.GetChild(0).gameObject.SetActive(false);}
}
