using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public int foo = 0;

    private void Start()
    {
        int f = PlayerPrefs.GetInt("storedKey", 6);
        Debug.Log(f);
        this.foo = f;
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    private void SavePrefs()
    {
        Debug.Log("Saving preferences");
        PlayerPrefs.SetInt("storedKey", foo);
    }

    private void OnDisable()
    {
        if (!Application.isPlaying)
        {
            SavePrefs();
        }
    }
}
