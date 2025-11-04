using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleUI : UIBase
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] CharacterSelectUI characterSelectUI;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        characterSelectUI.gameObject.SetActive(true);
        SoundManager.Instance.PlaySfxRandom(ESfxName.Click);
    }

    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
