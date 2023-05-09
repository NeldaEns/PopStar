using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : UIScreenBase
{
    [SerializeField] public Slider musicSlider, sfxSlider;

    private void Start()
    {
        sfxSlider.value = DataManager.ins.sfxSliderValue;
        DataManager.ins.sfxVolume = sfxSlider.value;
        musicSlider.value = DataManager.ins.musicSliderValue;
        DataManager.ins.musicVolume = musicSlider.value;
    }
    public void StartCasual()
    {
        DataManager.ins.survivalGame = false;
        DataManager.ins.classicGame = false;
        DataManager.ins.casualGame = true;
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreCasual == 0)
        {
            if (DataManager.ins.highScoreCasual == 0)
            {                
                DataManager.ins.start_new_game_casual = true;
                DataManager.ins.StartDataCasual();
                SceneManager.LoadScene(1);
                UIController.ins.ShowCasual();
            }
            else
            {
                RestartCasual();
            }
        }     
    }
    public void StartClassic()
    {
        DataManager.ins.survivalGame = false;
        DataManager.ins.casualGame = false;
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreClassic == 0)
        {   
            if(DataManager.ins.highScoreClassic == 0)
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
        DataManager.ins.casualGame = false;
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreSurvival == 0)
        {
            if (DataManager.ins.highScoreSurvival == 0)
            {
                DataManager.ins.start_new_game_survival = true;
                DataManager.ins.StartDataSurvival();
                SceneManager.LoadScene(1);
                UIController.ins.ShowSurvival();
            }
            else
            {
                RestartSurvival();
            }
        }
    }
    public void RestartCasual()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.casualGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_casual = true;
        DataManager.ins.ResetDataCasual();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void RestartClassic()
    {
        DataManager.ins.survivalGame = false;
        DataManager.ins.casualGame = false;
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(1);
        UIController.ins.ShowClassic();
    }
    public void RestartSurvival()
    {
        DataManager.ins.casualGame = false;
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_survival = true;
        DataManager.ins.ResetDataSurvival();
        SceneManager.LoadScene(1);
        UIController.ins.ShowSurvival();
    }
    public void ContinueCasual()
    {
        DataManager.ins.classicGame = false;
        DataManager.ins.casualGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_casual = false;
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual(); 
    }
    public void ContinueClassic()
    {
        DataManager.ins.survivalGame = false;
        DataManager.ins.casualGame = false; 
        DataManager.ins.classicGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = false; 
        SceneManager.LoadScene(1);
        UIController.ins.ShowClassic();
    }
    public void ContinueSurvival()
    {
        DataManager.ins.casualGame = false;
        DataManager.ins.classicGame = false;
        DataManager.ins.survivalGame = true;
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_survival = false;
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
        Application.Quit();
    }
    public override void Hide()
    {
        base.Hide();
    }

    public void MusicVolume()
    {
        DataManager.ins.musicVolume = musicSlider.value;
        DataManager.ins.SaveMusicVolume();
        DataManager.ins.musicSliderValue = musicSlider.value;
        DataManager.ins.SaveMusicSliderValue();
        AudioManager.ins.MusicVolume(musicSlider.value);
    }   

    public void SFXVolume()
    {
        DataManager.ins.sfxVolume = sfxSlider.value;
        DataManager.ins.SaveSFXVolume();
        DataManager.ins.sfxSliderValue = sfxSlider.value;
        DataManager.ins.SaveSFXSliderValue();
        AudioManager.ins.SFXVolume(sfxSlider.value);
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
