using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalGameOverScreen : UIScreenBase
{
    public Text scoreSurvivalText;
    public Text highScoreSurvivalText;

    public override void OnShow()
    {
        base.OnShow();
        ScoreSurvival();
        HighScoreSurvival();
    }
    public void ScoreSurvival()
    {
        scoreSurvivalText.text = DataManager.ins.scoreSurvival.ToString();
    }

    public void HighScoreSurvival()
    {
        highScoreSurvivalText.text = DataManager.ins.highScoreSurvival.ToString();
    }

    public void RestartGameSurvival()
    {
        DataManager.ins.start_new_game_survival = true;
        DataManager.ins.ResetDataSurvival();
        SceneManager.LoadScene(1);
        UIController.ins.ShowSurvival();
    }

    public void Menu()
    {
        Hide();
        AudioManager.ins.PlaySFX("click1");
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.ResetDataSurvival();
    }
}
