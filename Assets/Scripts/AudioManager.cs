using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;
    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSources;
    public static readonly string musicVolume = "musicVolume";
    public static readonly string sfxVolume = "sfxVolume";
    public const string first_time_play = "first_time_play";
    public float musicFloat, sfxFloat;

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
        FirstTimePlay();
    }

    public void FirstTimePlay()
    {
        if (PlayerPrefs.HasKey(first_time_play))
        {
            LoadDataSound();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play, 0);
            StartDataSound();
        }
    }

    public void LoadDataSound()
    {
        LoadSFXVoLume();
        LoadMusicVoLume();
    }

    public void StartDataSound()
    {
        SaveMusicVolume();
        SaveSFXVolume();
    }
    void Start()
    {
        PlayMusic("bg");
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
        musicFloat = volume;
      
        SaveMusicVolume();
    }

    public void SFXVolume(float volume)
    {
        sfxSources.volume = volume;
    }

    public void LoadMusicVoLume()
    {
        musicFloat = PlayerPrefs.GetFloat(musicVolume, musicSource.volume);
    }

    public void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat(musicVolume, musicFloat);
    }
    public void LoadSFXVoLume()
    {
        sfxFloat = PlayerPrefs.GetFloat(sfxVolume, 1);
    }

    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat(sfxVolume, sfxFloat);
    }
}

