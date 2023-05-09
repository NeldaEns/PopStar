using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSources;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic("bg");
        musicSource.volume = DataManager.ins.musicVolume;
        DataManager.ins.LoadMusicVolume();
        
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {           
            musicSource.loop = s.loop;
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSources.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        DataManager.ins.musicVolume = musicSource.volume;
        musicSource.volume = volume;
        DataManager.ins.SaveMusicVolume();
    }

    public void SFXVolume(float volume)
    {
        DataManager.ins.sfxVolume = sfxSources.volume;
        sfxSources.volume = volume;
        DataManager.ins.SaveSFXVolume();
    }

}

