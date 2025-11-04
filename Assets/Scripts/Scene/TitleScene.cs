using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    SoundManager soundManager;
    private void Start()
    {
        soundManager = SoundManager.Instance;
        soundManager.PlayBgm(EBgmName.Title);
    }
}
