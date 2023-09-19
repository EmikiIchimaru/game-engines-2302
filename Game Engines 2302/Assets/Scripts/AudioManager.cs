using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;

    public Sound[] sounds;

    public static float bgmX;
    public static float sfxX;

    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
            return;
        } 
        else 
        { 
            Instance = this; 
        } 

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }

        bgmX = 0.5f;
        sfxX = 0.5f;
    }

    void Start()
    {
        Play("bgm");
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { return; }
        s.source.volume = s.volume * sfxX;
        s.source.Play();
        Debug.Log(s.source.volume.ToString());
    }

    public void UpdateBGMVolume()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "bgm");
        if (s == null) { return; }
        s.source.volume = s.volume * bgmX;
    }

    
}
