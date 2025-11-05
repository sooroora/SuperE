using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] Button confirmButton;
    [SerializeField] private Image selectedCharacterImage; 
    [SerializeField] private Sprite[] characterSprites;    
    private int selectedIndex = 0;

    public void Start()
    {
        selectedIndex = 0;
        confirmButton.onClick.AddListener(OnConfirmCharacter);
    }

    public void OnSelectCharacter(int index)
    {
        selectedIndex = index;
        selectedCharacterImage.sprite = characterSprites[index];
    }


    public void OnConfirmCharacter()
    {
        SoundManager.Instance.PlaySfxOnce(ESfxName.Click);
        ECharacterName characterName = (ECharacterName)selectedIndex;
        
        PlayerPrefsManager.SetIntValue(ESceneTransferData.CharacterName,(int)characterName);
        SceneTransferManager.LoadScene(ESceneName.GameScene);
    }

}
