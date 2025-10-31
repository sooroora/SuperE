using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private Image selectedCharacterImage; 
    [SerializeField] private Sprite[] characterSprites;    
    private int selectedIndex = 0; 

    
    public void OnSelectCharacter(int index)
    {
        selectedIndex = index;
        selectedCharacterImage.sprite = characterSprites[index];
    }


    public void OnConfirmCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedIndex);
        SceneManager.LoadScene("GameScene");
    }

}
