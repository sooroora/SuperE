using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionUI : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // 이전 설정 불러오기
        masterSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.MasterVolume)??1.0f;
        bgmSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.BgmVolume)??1.0f;
        sfxSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.SfxVolume)??1.0f;

        // 슬라이더 이벤트 연결
        masterSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetVolume("Master", v));
        bgmSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetVolume("BGM", v));
        sfxSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetVolume("SFX", v));
    }
}
