using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "Sound Data/CreateAudioClip")]
public class SoundClip : ScriptableObject
{
    public List<AudioClip> tables;
    
    public AudioClip GetRandomClip()
    {
        if (tables.Count == 0)
            return null;

        int num = Random.Range(0, tables.Count);
        return tables[num];
    }

    public AudioClip GetClip(int idx = 0)
    {
        if (tables.Count <= idx)
            return null;
        
        return tables[idx];
    }
    
}