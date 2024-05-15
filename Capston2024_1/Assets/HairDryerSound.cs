using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryerSound : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        audio = SoundManager.Instance.BGM_Object.GetComponent<AudioSource>();
    }

    public void DryerActivate()
    {
        audio.clip = clip;
        audio.Play();
    }

    public void DryerDeactivate()
    {
        audio.clip = null;
        audio.Stop();
    }
}
