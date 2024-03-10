using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] Dictionary<BGM_list, AudioClip> BGM_audioclips = new Dictionary<BGM_list, AudioClip>();
    [SerializeField] Dictionary<SFX_list, AudioClip> SFX_audioclips = new Dictionary<SFX_list, AudioClip>();

    [SerializeField] public float volume_BGM = 1f;
    [SerializeField] public float volume_SFX = 1f;

    [SerializeField] public List<BGM_Datas> BGM_datas = new List<BGM_Datas>();
    [SerializeField] public List<SFX_Datas> SFX_datas = new List<SFX_Datas>();

    [SerializeField] public GameObject BGM_Object;
    [SerializeField] public GameObject SFX_Object;

    // ���� ȿ����
    private SFX_list toStopSfx;
    private BGM_list toStopBGM;

    private enum SoundType {
        BGM,
        SFX,
    }

    [System.Serializable]
    [SerializeField]
    public struct SFX_Datas
    {
        public SFX_list sfx_name;
        public AudioClip audio;
    }

    [System.Serializable]
    [SerializeField]
    public struct BGM_Datas
    {
        public BGM_list bgm_name;
        public AudioClip audio;
    }


    // ȿ���� ���
    public enum SFX_list
    {
        GLASS,
        BRUSH,
        TAPE,
    }

    // ����� ���
    public enum BGM_list
    {
        Home_BGM,
    }

    void Start()
    {
        // ����Ʈ�� ���� SFX audioClip �� ��� dictionary�� ����
        for (int i = 0; i < SFX_datas.Count; i++)
        {
            if (SFX_datas[i].audio == null) continue; // ȿ���� ������ ����X
            SFX_audioclips.Add(SFX_datas[i].sfx_name, SFX_datas[i].audio);
        }
        // ����Ʈ�� ���� BGM audioClip �� ��� dictionary�� ����
        for (int i = 0; i < BGM_datas.Count; i++)
        {
            if (BGM_datas[i].audio == null) continue; // ����� ������ ����X
            BGM_audioclips.Add(BGM_datas[i].bgm_name, BGM_datas[i].audio);
        }
    }


    // ���� ��� - ���
    public void PlayBGM(BGM_list _type)
    {
        // ���� �̸�
        BGM_list playSoundName = _type;

        // ���� ��ü
        GameObject soundObject = BGM_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.clip = BGM_audioclips[playSoundName]; // ���� �ҷ�����
        audioSource.volume = volume_BGM; // ��������
        audioSource.Play(); // ���� ���
    }

    // ���� ��� - ȿ����
    public void PlaySFX(SFX_list _type)
    {
        // ���� �̸�
        SFX_list playSoundName = _type;

        // ���� ��ü
        GameObject soundObject = SFX_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.volume = volume_SFX; // ��������
        audioSource.PlayOneShot(SFX_audioclips[playSoundName]); // ���� ���
    }



    // �������� ���� �ٲܶ� ���
    public void ChangeVolume_BGM(float _vol)
    {
        volume_BGM = _vol;
        AudioSource audioSource = BGM_Object.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.volume = volume_BGM; // ��������
    }

    // �������� ���� �ٲܶ� ���
    public void ChangeVolume_SFX(float _vol)
    {
        volume_SFX = _vol;
        AudioSource audioSource = SFX_Object.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.volume = volume_SFX; // ��������
    }
}