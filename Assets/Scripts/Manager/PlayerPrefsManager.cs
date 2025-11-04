using System;
using UnityEngine;


public static class PlayerPrefsManager
{
    public static int GetIntValue<T>(T key) where T : Enum
    {
        if (PlayerPrefs.HasKey(key.ToString()))
        {
            return PlayerPrefs.GetInt(key.ToString());
        }
        return 0;
    }
    
    // 나중에 바꿔야함
    public static float GetFloatValue<T>(T key) where T : Enum
    {
        if (PlayerPrefs.HasKey(key.ToString()))
        {
            return PlayerPrefs.GetFloat(key.ToString());
        }

        return 1.0f;
    }

    public static string GetStringValue<T>(T key) where T : Enum
    {
        if (PlayerPrefs.HasKey(key.ToString()))
        {
            return PlayerPrefs.GetString(key.ToString());
        }
        return "";
    }

    public static void SetIntValue<T>(T key, int value) where T : Enum
    {
        PlayerPrefs.SetInt(key.ToString(), value); 
    }
    
    public static void SetFloatValue<T>(T key, float value) where T : Enum
    {
        PlayerPrefs.SetFloat(key.ToString(), value);
    }
    
    public static void SetStringValue<T>(T key, string value) where T : Enum
    {
        PlayerPrefs.SetString(key.ToString(), value);
    }
}
