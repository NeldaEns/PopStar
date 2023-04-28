using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenCasual : UIScreenBase
{
    public Text scoreCasualText;
    public Text highScoreCasualText;    

    public override void OnShow()
    {
        base.OnShow();
        ScoreCasual();
        HighScoreCasual();
    }
    public void ScoreCasual()
    {
        scoreCasualText.text = DataManager.ins.scoreCasual.ToString();
    }

    public void HighScoreCasual()
    {
        highScoreCasualText.text = DataManager.ins.highScoreCasual.ToString();
    }

    public void RestartGameCasual()
    {
        DataManager.ins.start_new_game_casual = true;
        DataManager.ins.ResetDataCasual();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void Menu()
    {
        Hide();
        AudioManager.ins.Play("click1");
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.ResetDataCasual();
    }
}
