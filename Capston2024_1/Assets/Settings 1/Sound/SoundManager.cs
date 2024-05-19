using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Dictionary<BGM_list, AudioClip> BGM_audioclips = new Dictionary<BGM_list, AudioClip>();
    [SerializeField] Dictionary<SFX_list, AudioClip> SFX_audioclips = new Dictionary<SFX_list, AudioClip>();
    [SerializeField] Dictionary<TTS_list, AudioClip> TTS_audioclips = new Dictionary<TTS_list, AudioClip>();

    [SerializeField] public float volume_BGM = 1f;
    [SerializeField] public float volume_SFX = 1f;

    [SerializeField] public List<BGM_Datas> BGM_datas = new List<BGM_Datas>();
    [SerializeField] public List<SFX_Datas> SFX_datas = new List<SFX_Datas>();
    [SerializeField] public List<TTS_Datas> TTS_datas = new List<TTS_Datas>();

    [SerializeField] public GameObject BGM_Object;
    [SerializeField] public GameObject SFX_Object;
    [SerializeField] public GameObject TTS_Object;

    // ���� ȿ����
    private SFX_list toStopSfx;
    private BGM_list toStopBGM;

    public static SoundManager Instance;

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

    [System.Serializable]
    [SerializeField]
    public struct TTS_Datas
    {
        public TTS_list tts_name;
        public AudioClip audio;
    }


    // ȿ���� ���
    public enum SFX_list
    {
        GLASS,
        BRUSH,
        TAPE,
        CAMERA,

        BOTTLECAP_1,BOTTLECAP_2,BOTTLECAP_3,BOTTLECAP_4,BOTTLECAP_5,BOTTLECAP_6,BOTTLECAP_7,BOTTLECAP_8,BOTTLECAP_9,BOTTLECAP_10,
        WOOSH_1, WOOSH_2, WOOSH_3, WOOSH_4, WOOSH_5, WOOSH_6,WOOSH_7,WOOSH_8,WOOSH_9,WOOSH_10,
        GLASS_UP_1, GLASS_UP_2, GLASS_UP_3, GLASS_UP_4, GLASS_UP_5,
        GLASS_DOWN_1,GLASS_DOWN_2, GLASS_DOWN_3, GLASS_DOWN_4, GLASS_DOWN_5,
        DROP_OBJ_1, DROP_OBJ_2, DROP_OBJ_3,
        IGNITE_1, IGNITE_2, IGNITE_3,
        CABINET_CLOSE_1, CABINET_CLOSE_2, CABINET_CLOSE_3, CABINET_CLOSE_4,
        CABINET_OPEN_1, CABINET_OPEN_2, CABINET_OPEN_3, CABINET_OPEN_4,
        WOOD_CLOSE_1, WOOD_CLOSE_2, WOOD_CLOSE_3, WOOD_CLOSE_4,
        WOOD_OPEN_1, WOOD_OPEN_2, WOOD_OPEN_3,WOOD_OPEN_4,
        BUTTON_1,BUTTON_2, BUTTON_3, BUTTON_4, BUTTON_5, BUTTON_6, BUTTON_7, BUTTON_8, BUTTON_9, BUTTON_10, BUTTON_11, BUTTON_12,
        SWITCH_1, SWITCH_2, SWITCH_3, SWITCH_4, SWITCH_5, SWITCH_6,SWITCH_7,SWITCH_8,SWITCH_9,SWITCH_10,SWITCH_11,SWITCH_12,
        
        DOOR_OPEN_1,DOOR_OPEN_2, DOOR_OPEN_3,DOOR_OPEN_4,
        DOOR_CLOSE_1,DOOR_CLOSE_2, DOOR_CLOSE_3,DOOR_CLOSE_4,

        FLAP_1,FLAP_2, FLAP_3, FLAP_4,
        PUT_ON_1, PUT_OFF_1,
        HOOD_PULL_UP,
        HOT_PLATE,
        LIQUID_1,LIQUID_2, LIQUID_3,
        CONTAINER_OPEN, CONTAINER_CLOSE,
        TOOL_PICKUP, TOOL_PICKDOWN,
        PINSET, PINSET_PICK,

        SPRAY,
    }

    // ����� ���
    public enum BGM_list
    {
        Home_BGM,
    }

    // TTS ���
    public enum TTS_list
    {
        // Ʃ�丮��
        TUTORIAL_1, TUTORIAL_2, TUTORIAL_3, TUTORIAL_4, TUTORIAL_5, TUTORIAL_6, TUTORIAL_7, TUTORIAL_8, TUTORIAL_9,
        TUTORIAL_SOLID_QUIZ_1, TUTORIAL_SOLID_QUIZ_2, TUTORIAL_SOLID_QUIZ_3, TUTORIAL_SOLID_QUIZ_3_O, TUTORIAL_SOLID_QUIZ_3_X, TUTORIAL_SOLID_QUIZ_4, TUTORIAL_SOLID_QUIZ_4_O, TUTORIAL_SOLID_QUIZ_4_X,
        TUTORIAL_WATER_QUIZ_1, TUTORIAL_WATER_QUIZ_2, TUTORIAL_WATER_QUIZ_2_O, TUTORIAL_WATER_QUIZ_2_X, TUTORIAL_WATER_QUIZ_3, TUTORIAL_WATER_QUIZ_3_O, TUTORIAL_WATER_QUIZ_3_X, TUTORIAL_WATER_QUIZ_4,
    
        // ���� NPC
        CRIME_DESCRIPTION_1, CRIME_DESCRIPTION_2, CRIME_DESCRIPTION_3, CRIME_DESCRIPTION_4, CRIME_DESCRIPTION_5, CRIME_DESCRIPTION_6, CRIME_DESCRIPTION_7,
        CRIME_PUT_ON_1, CRIME_PUT_ON_2, CRIME_PUT_ON_3,
        CRIME_UI_1, CRIME_UI_2, CRIME_UI_3, CRIME_UI_4, CRIME_UI_5,
        CRIME_HOW_1, CRIME_HOW_2, CRIME_HOW_3, CRIME_HOW_4, CRIME_HOW_5, CRIME_HOW_6, CRIME_HOW_7, CRIME_HOW_8,
        CRIME_ORDER_1,CRIME_ORDER_2, CRIME_ORDER_3,

        // �Ž� NPC
        CRIME_RECHECK,
        CRIME_RATE1, CRIME_RATE_2, CRIME_RATE_3,
        CRIME_PRE1, CRIME_PRE_2, CRIME_PRE_3, CRIME_PRE_4,

        // LAB NPC
        LAB_DESCRIPTION_1, LAB_DESCRIPTION_2, LAB_DESCRIPTION_3, LAB_DESCRIPTION_4, LAB_DESCRIPTION_5, LAB_DESCRIPTION_6, LAB_DESCRIPTION_7, LAB_DESCRIPTION_8,
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
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
        // ����Ʈ�� ���� TTS audioClip �� ��� dictionary�� ����
        for (int i = 0; i < TTS_datas.Count; i++)
        {
            if (TTS_datas[i].audio == null) continue; // ����� ������ ����X
            TTS_audioclips.Add(TTS_datas[i].tts_name, TTS_datas[i].audio);
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

    // �޼��� �����ε�
    // ���� ��� - ȿ����
    public void PlaySFX(int _code)
    {
        // ���� �̸�
        SFX_list playSoundName = (SFX_list)_code;

        // ���� ��ü
        GameObject soundObject = SFX_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.volume = volume_SFX; // ��������
        audioSource.PlayOneShot(SFX_audioclips[playSoundName]); // ���� ���
    }

    // ���� ��� - TTS
    public void PlayTTS(TTS_list _type)
    {
        // ���� �̸�
        TTS_list playSoundName = _type;

        // ���� ��ü
        GameObject soundObject = TTS_Object;
        AudioSource audioSource = soundObject.GetComponent<AudioSource>(); // ������Ʈ �ҷ�����
        audioSource.volume = volume_SFX; // ��������

        audioSource.Stop(); // ���� ������ �ִٸ� (tts�� �ִٸ�) ���߰�, Ŭ�� �ٽ� ���� �� ���
        audioSource.clip = TTS_audioclips[playSoundName];
        audioSource.Play();
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