using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : UIScreenBase
{
    [SerializeField] private Slider musicSlider, sfxSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            MusicVolume();
        }
    }
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

    public void StartClassic()
    {
        if(DataManager.ins.scoreClassic == 0)
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
        float volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        MusicVolume();
    }

    public void SFXVolume()
    {
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
