using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController 
{
    private AudioSource source;

    public SoundController(AudioSource source)
    {
        this.source = source;
    }

    public void Background()
    {
        if (PlayerPrefs.GetInt(KEYS.sound) > 0)
        {
            source.mute = true;
        } else
        {
            source.mute = false;
        }
    }
}
