using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : UIScreenBase
{
    [SerializeField] public Slider musicSlider, sfxSlider;
   
    public void StartCasual()
    {
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

    private void Start()
    {
        sfxSlider.value = DataManager.ins.sfxSliderValue;       
        DataManager.ins.sfxVolume = sfxSlider.value;
        musicSlider.value = DataManager.ins.musicSliderValue;
        DataManager.ins.musicVolume = musicSlider.value;
    }

    public void StartClassic()
    {
        AudioManager.ins.PlaySFX("click");
        if (DataManager.ins.scoreClassic == 0)
        {
            if(DataManager.ins.highScoreClassic == 0)
            {
                DataManager.ins.start_new_game_classic = true;
                DataManager.ins.StartDataClassic();
                SceneManager.LoadScene(2);
                UIController.ins.ShowClassic();
            }
            else
            {
                RestartClassic();
            }
        }
    }
    public void RestartCasual()
    {
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_casual = true;
        DataManager.ins.ResetDataCasual();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void RestartClassic()
    {
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(2);
        UIController.ins.ShowClassic();
    }
    public void ContinueCasual()
    {
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_casual = false;
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual(); 
    }

    public void ContinueClassic()
    {
        AudioManager.ins.PlaySFX("click1");
        DataManager.ins.start_new_game_classic = false; 
        SceneManager.LoadScene(2);
        UIController.ins.ShowClassic();
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
