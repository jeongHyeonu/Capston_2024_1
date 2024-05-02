using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUX_Liquid : MonoBehaviour
{
    public int stepCount = 0;

    [SerializeField] GameObject gripUX;
    [SerializeField] GameObject triggerUX;

    GameObject createdUX;

    [SerializeField] List<GameObject> TutorialBoard;
    [SerializeField] List<GameObject> HologramObjects;

    public void GripUX_ON(GameObject obj)
    {
        if (!createdUX) Destroy(createdUX);
        Vector3 objPos = obj.transform.position + new Vector3(0, .15f, .2f);
        createdUX = Instantiate(gripUX, objPos, Quaternion.Euler(new Vector3(0f,-180f,0f)));
    }

    public void TriggerUX_ON(GameObject obj)
    {
        if (!createdUX) Destroy(createdUX);
        Vector3 objPos = obj.transform.position + new Vector3(0, .15f, .2f);
        createdUX = Instantiate(triggerUX, objPos, Quaternion.Euler(Vector3.zero));
    }

    public void UX_OFF()
    {
        Destroy(createdUX);
    }

    public void TutorialStep(int step)
    {
        if (step != stepCount) return;
        stepCount++;

        TutorialBoard[stepCount].SetActive(true);
        HologramObjects[stepCount].SetActive(true);
        HologramObjects[stepCount-1].SetActive(false);
    }
}
