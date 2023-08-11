using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : UIScreenBase
{
    [SerializeField] public Slider musicSlider, sfxSlider;
    public GameObject musicButton;
    public GameObject sfxButton;

    private void Start()
    {
        UpdateButton();
        sfxSlider.value = DataManager.ins.sfxVolume;
        AudioManager.ins.SFXVolume(sfxSlider.value);
        musicSlider.value = DataManager.ins.musicVolume;
        AudioManager.ins.MusicVolume(musicSlider.value);
    }
    private void Update()
    {
        UpdateButton(); 
    }
    public void StartClassic()
    {
        DataManager.ins.survivalGame = false;
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreClassic == 0)
        {
            if (DataManager.ins.highScoreClassic == 0)
            {                
                DataManager.ins.start_new_game_classic = true;
                DataManager.ins.StartDataClassic();              
                SceneManager.LoadScene(1);
                UIController.ins.ShowClassic();
            }
            else
            {
                RestartClassic();
            }
        }     
    }
    public void StartSurvival()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreSurvival == 0)
        {
            if (DataManager.ins.highScoreSurvival == 0)
            {
                DataManager.ins.start_new_game_survival = true;
                DataManager.ins.StartDataSurvival();
                DataManager.ins.timeActive = true;
                SceneManager.LoadScene(1);
                UIController.ins.ShowSurvival();
            }
            else
            {
                RestartSurvival();
            }
        }
    }
    public void RestartClassic()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(1);
        UIController.ins.ShowClassic();
    }

    public void RestartSurvival()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_survival = true;
        DataManager.ins.ResetDataSurvival();
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(1);
        UIController.ins.ShowSurvival();
    }
    public void ContinueClassic()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = false;
        SceneManager.LoadScene(1);
        UIController.ins.ShowClassic(); 
    }

    public void ContinueSurvival()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_survival = false;
        DataManager.ins.currentTime = DataManager.ins.maxTime;
        DataManager.ins.timeActive = true;
        SceneManager.LoadScene(1);
        UIController.ins.ShowSurvival();
    }
    public override void OnShow()
    {
        base.OnShow();
    }
    public void Back()
    {       
        AudioManager.ins.PlaySFX("click");
    }
    public override void Hide()
    {
        base.Hide();
    }

    public void MusicVolume()
    {
        DataManager.ins.musicVolume = musicSlider.value;
        DataManager.ins.SaveMusicVolume();
        AudioManager.ins.MusicVolume(musicSlider.value);
    }   

    public void SFXVolume()
    {
        DataManager.ins.sfxVolume = sfxSlider.value;
        DataManager.ins.SaveSFXVolume();
        AudioManager.ins.SFXVolume(sfxSlider.value);
    }

    public void UpdateButton()
    {
        if (DataManager.ins.musicVolume <= 0.2f)
        {
            musicButton.SetActive(true);
        }
        else
        {
            musicButton.SetActive(false);
        }
        if (DataManager.ins.sfxVolume <= 0.2f)
        {
            sfxButton.SetActive(true);
        }
        else
        {
            sfxButton.SetActive(false);
        }
    }

    public void MusicButton()
    {
        AudioManager.ins.PlaySFX("click");
    }

    public void SFXButton()
    {
        AudioManager.ins.PlaySFX("click");
    }
}
