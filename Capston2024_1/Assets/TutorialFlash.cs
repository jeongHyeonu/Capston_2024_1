using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFlash : MonoBehaviour
{
    [SerializeField] GameObject flashLight;
    [SerializeField] GameObject hologramLight;

    [SerializeField] GameObject tutoBoard1;
    [SerializeField] GameObject tutoBoard2;
    [SerializeField] GameObject cameraHologram;
    [SerializeField] TutorialCamera tutoCam;

    bool isFirstStep = false;
    bool isSecondStep = false;

    public bool isGrabbing = false;

    Vector3 originPos;
    Quaternion originRot;

    private void Start()
    {
        originPos = transform.position;
        originRot = transform.rotation;
        isFirstStep = true;
    }

    public void GrabFlashLight()
    {
        flashLight.SetActive(true);
        hologramLight.SetActive(true);

        if (isFirstStep) { StartCoroutine(FirstCheck()); }
        if (isSecondStep) { StartCoroutine(SecondCheck()); }
        isGrabbing = true;
    }

    public void UngrabFlashLight()
    {
        flashLight.SetActive(false);
        hologramLight.SetActive(false);
        this.transform.position = originPos;
        this.transform.rotation = originRot;
        isGrabbing = false;
    }

    IEnumerator FirstCheck()
    {
        yield return new WaitForSeconds(.5f);

        if (Vector3.Distance(hologramLight.transform.position, this.transform.position) < .1f)
        {
            isFirstStep = false;
            isSecondStep = true;
            hologramLight.SetActive(false);
            tutoBoard1.SetActive(true);
            cameraHologram.SetActive(true);

            tutoCam.GetComponent<GrabInteractable>().enabled = true;
            tutoCam.GetComponent<Grabbable>().enabled = true;
            tutoCam.GetComponent<TutorialCamera>().enabled = true;
        }

        if (isFirstStep) StartCoroutine(FirstCheck());
    }

    IEnumerator SecondCheck()
    {
        yield return new WaitForSeconds(.5f);

        if (Vector3.Distance(hologramLight.transform.position, this.transform.position) < .1f)
        {
            isSecondStep = false;
            hologramLight.SetActive(false);
            tutoBoard2.SetActive(true);
            cameraHologram.SetActive(true);
            tutoCam.secondStep_ON();
        }

        if (isSecondStep) StartCoroutine(SecondCheck());
    }
}
