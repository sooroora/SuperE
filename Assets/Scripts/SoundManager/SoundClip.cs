using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "Sound Data/CreateAudioClip")]
public class SoundClip : ScriptableObject
{
   public List<AudioClip> tables;
}
