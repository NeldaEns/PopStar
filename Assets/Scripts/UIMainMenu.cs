using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : UIScreenBase
{
    public Image musicButtonOn;
    public Image musicButtonOff;
    public Image sfxButtonOn;
    public Image sfxButtonOff;
    private void Start()
    {
        DataManager.ins.AudioUpdate();
         ToggleSFX();
        if (musicButtonOn.enabled)
        {
            AudioManager.ins.musicSource.Play();
        }
        else
        {
            AudioManager.ins.musicSource.Pause();
        }
        MusicButton();
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
        if(!DataManager.ins.musicMuted)
        {
            DataManager.ins.musicMuted = true;
            AudioManager.ins.musicSource.Pause();
        }
        else
        {
            DataManager.ins.musicMuted = false;
            AudioManager.ins.musicSource.Play();
        }
        DataManager.ins.SaveMusic();
        MusicButton();
    }

    
    public void MusicButton()
    {
        AudioManager.ins.PlaySFX("click");
        if(!DataManager.ins.musicMuted)
        {
            musicButtonOn.enabled = true;
            musicButtonOff.enabled = false;
        }
        else
        {
            musicButtonOn.enabled = false;
            musicButtonOff.enabled = true;
        }
    }



    public void ToggleSFX()
    {
        AudioManager.ins.PlaySFX("click");
        AudioManager.ins.ToggleSFX();
        if(AudioManager.ins.sfxSources.mute)
        {
            sfxButtonOn.enabled = false;
            sfxButtonOff.enabled = true;
        }
        else
        {
            sfxButtonOn.enabled = true;
            sfxButtonOff.enabled = false;
        }
    }

}
