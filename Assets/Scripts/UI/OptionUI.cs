using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject sliderPanel;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {

        masterSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.MasterVolume);
        bgmSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.BgmVolume);
        sfxSlider.value = PlayerPrefsManager.GetFloatValue<ESoundSettingName>(ESoundSettingName.SfxVolume);


        masterSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetMasterVolume(v));
        bgmSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetBgmVolume(v));
        sfxSlider.onValueChanged.AddListener(v => SoundManager.Instance.SetSfxVolume(v));
    }
    public GameObject slidersPanel;
    private bool isActive = false;
    public void ToggleSliders()
    {
        isActive = !isActive;
        slidersPanel.SetActive(isActive);
    }
    public void ToggleSliderPanel()
    {
        bool isActive = !sliderPanel.activeSelf;
        sliderPanel.SetActive(isActive);
        if (isActive)
        {
            Time.timeScale = 0f; // 게임 일시정지
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f; // 게임 재개
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


}
