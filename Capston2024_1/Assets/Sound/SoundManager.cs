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

    // 멈출 효과음
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


    // 효과음 목록
    public enum SFX_list
    {
        GLASS,
        BRUSH,
        TAPE,
    }

    // 배경음 목록
    public enum BGM_list
    {
        Home_BGM,
    }

    void Start()
    {
        // 리스트에 넣은 SFX audioClip 을 모두 dictionary에 저장
        for (int i = 0; i < SFX_datas.Count; i++)
        {
            if (SFX_datas[i].audio == null) continue; // 효과음 없으면 저장X
            SFX_audioclips.Add(SFX_datas[i].sfx_name, SFX_datas[i].audio);
        }
        // 리스트에 넣은 BGM audioClip 을 모두 dictionary에 저장
        for (int i = 0; i < BGM_datas.Count; i++)
        {
            if (BGM_datas[i].audio == null) continue; // 배경음 없으면 저장X
            BGM_audioclips.Add(BGM_datas[i].bgm_name, BGM_datas[i].audio);
        }
    }


    // 사운드 재생 - 배경
    public void PlayBGM(BGM_list _type)
    {
        // 사운드 이름
        BGM_list playSoundName = _type;

        // 사운드 객체
        GameObject soundObject = BGM_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // 컴포넌트 불러오기
        audioSource.clip = BGM_audioclips[playSoundName]; // 음악 불러오기
        audioSource.volume = volume_BGM; // 음량조절
        audioSource.Play(); // 음악 재생
    }

    // 사운드 재생 - 효과음
    public void PlaySFX(SFX_list _type)
    {
        // 사운드 이름
        SFX_list playSoundName = _type;

        // 사운드 객체
        GameObject soundObject = SFX_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // 컴포넌트 불러오기
        audioSource.volume = volume_SFX; // 음량조절
        audioSource.PlayOneShot(SFX_audioclips[playSoundName]); // 음악 재생
    }



    // 설정에서 볼륨 바꿀때 사용
    public void ChangeVolume_BGM(float _vol)
    {
        volume_BGM = _vol;
        AudioSource audioSource = BGM_Object.GetComponent<AudioSource>(); // 컴포넌트 불러오기
        audioSource.volume = volume_BGM; // 음량조절
    }

    // 설정에서 볼륨 바꿀때 사용
    public void ChangeVolume_SFX(float _vol)
    {
        volume_SFX = _vol;
        AudioSource audioSource = SFX_Object.GetComponent<AudioSource>(); // 컴포넌트 불러오기
        audioSource.volume = volume_SFX; // 음량조절
    }
}