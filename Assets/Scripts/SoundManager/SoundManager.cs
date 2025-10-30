using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

// 옛날에 만든거
// string으로 찾아야해서 불편함. 나중에 enum 같은걸로 바꿔야함!!
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;


    public static float MasterVolume
    {
        get => _masterVolume;
        set => _masterVolume = value;
    }

    public static float SfxVolume
    {
        get => _sfxVolume;
        private set => _sfxVolume = value;
    }

    public static float BgmVolume
    {
        get => _bgmVolume;
        private set => _bgmVolume = value;
    }

    private static float _sfxVolume = 1.0f;
    private static float _bgmVolume = 1.0f;
    private static float _masterVolume = 1.0f;


    public static SoundManager Instance
    {
        get => instance;
        private set => instance = value;
    }

    Dictionary<SFXName, SoundClip> SFXTable = new Dictionary<SFXName, SoundClip>();
    Dictionary<BGMName, SoundClip> BGMTable = new Dictionary<BGMName, SoundClip>();

    AudioSource bgmAudioSource;
    private List<AudioSource> sfxAudioSources;


    private void Awake()
    {
        if (instance == null)
        {
            gameObject.name = "SoundManager";
            DontDestroyOnLoad(gameObject);
            instance = this;

            bgmAudioSource  = gameObject.AddComponent<AudioSource>();
            sfxAudioSources = new List<AudioSource>();

            // 일단 풀에 10개 넣어
            for (int i = 0; i < 10; ++i)
            {
                AudioSource aSource = gameObject.AddComponent<AudioSource>();
                aSource.playOnAwake = false;
                sfxAudioSources.Add(aSource);
            }

            instance.ReadSoundClips();
        }
    }

    void ReadSoundClips()
    {
        SoundClip[] bgmClips = Resources.LoadAll<SoundClip>("Sounds/BGM");
        SoundClip[] sfxClips = Resources.LoadAll<SoundClip>("Sounds/SFX");

        SFXTable = ((SFXName[])Enum.GetValues(typeof(SFXName))).ToDictionary(part => part,
            part => (SoundClip)null);

        BGMTable = ((BGMName[])Enum.GetValues(typeof(BGMName))).ToDictionary(part => part,
            part => (SoundClip)null);

        for (int i = 0; i < bgmClips.Length; i++)
        {
            if (Enum.TryParse(bgmClips[i].name, out BGMName bgmName))
            {
                BGMTable[bgmName] = bgmClips[i];
            }
        }

        for (int i = 0; i < sfxClips.Length; i++)
        {
            if (Enum.TryParse(sfxClips[i].name, ignoreCase: true, out SFXName sfxName))
            {
                SFXTable[sfxName] = sfxClips[i];
            }
        }

        // 오마갓 C# 버전이 안맞대!!!!!!!!
        // 프로젝트 세팅을 바꿔야 한대
        //Enum.GetValues<SoundName>().ToDictionary(part => part, part => null);
    }

    private void Update()
    {
        //테스트
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlaySfxRandom(SFXName.Click, Random.Range(0.1f, 1f));
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            AllSfxStop();
        }
    }

    public void PlaySfxRandom(SFXName sfxName, float volume = 1.0f)
    {
        AudioClip aClip = null;
        if (SFXTable.TryGetValue(sfxName, out SoundClip clip))
        {
            aClip = clip.GetRandomClip();
        }

        PlaySfxOnce(aClip, volume);
    }

    public void PlaySfxOnce(SFXName sfxName, float _volume = 1.0f)
    {
        PlaySfxOnce(sfxName, 0, _volume);
    }

    public void PlaySfxOnce(SFXName sfxName, int idx = 0, float volume = 1.0f)
    {
        AudioClip aClip = null;
        if (SFXTable.TryGetValue(sfxName, out SoundClip clip))
        {
            aClip = clip.GetClip(idx);
        }

        PlaySfxOnce(aClip, volume);
    }

    void PlaySfxOnce(AudioClip aClip, float _volume = 1.0f)
    {
        if (aClip != null)
        {
            AudioSource audioSource = GetSFXAudioSource();
            audioSource.volume = _volume;
            audioSource.clip   = aClip;
            audioSource.Play();
        }
    }

    public void PlayBgm(BGMName bgmName, float _volume = 1.0f, bool _loop = true)
    {
        AudioClip aClip = null;
        if (BGMTable.TryGetValue(bgmName, out SoundClip clip))
        {
            aClip = clip.GetClip();
        }

        if (aClip != null)
        {
            bgmAudioSource.Stop();
            bgmAudioSource.volume = _volume;
            bgmAudioSource.loop   = _loop;
            bgmAudioSource.clip   = aClip;
            bgmAudioSource.Play();
        }
    }

    public void AllStop()
    {
        BgmStop();
        AllSfxStop();
    }

    public void BgmStop()
    {
        bgmAudioSource.Stop();
    }

    public void AllSfxStop()
    {
        foreach (AudioSource aSource in sfxAudioSources)
        {
            aSource.Stop();
        }
    }

    AudioSource GetSFXAudioSource()
    {
        foreach (AudioSource audioSource in sfxAudioSources)
        {
            if (audioSource.isPlaying == false)
                return audioSource;
        }

        // 추가 안하고 제일 오래된 애를 쓰는 방법도 있음.
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSources.Add(newAudioSource);
        return newAudioSource;
    }

    void InitMasterVolume()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            
        }
    }

    public void SetSfxVolume(float volume)
    {
        //if(PlayerPrefs.HasKey("SfxVolume"))
    }

    public void SetBGMVolume(float volume)
    {
        
    }
}