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

    
    public void OnSelectCharacter(int index)
    {
        selectedIndex = index;
        selectedCharacterImage.sprite = characterSprites[index];
        confirmButton.onClick.AddListener(OnConfirmCharacter);
    }


    public void OnConfirmCharacter()
    {
        ECharacterName characterName = (ECharacterName)selectedIndex;
        
        PlayerPrefsManager.SetIntValue(ESceneTransferData.CharacterName,(int)characterName);
        //PlayerPrefs.SetInt("SelectedCharacter", selectedIndex);
        SceneTransferManager.LoadScene(ESceneName.GameScene);
        //SceneManager.LoadScene("GameScene");
    }

}
