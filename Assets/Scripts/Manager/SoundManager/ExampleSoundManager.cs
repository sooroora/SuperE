using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    SoundManager soundManager;
    void Start()
    {
        soundManager= SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            soundManager.PlaySfxOnce(ESfxName.Click);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            soundManager.PlayBgm(EBgmName.InGame);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            soundManager.BgmStop();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            soundManager.SetMasterVolume(soundManager.MasterVolume + 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            soundManager.SetMasterVolume(soundManager.MasterVolume - 0.1f);
        }
    }
}
