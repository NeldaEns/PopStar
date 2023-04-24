using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : UIScreenBase
{
    public Text scoreCasualText;
    public Text highScoreCasualText;
    public Text scoreClassicText;
    public Text highScoreClassicText;

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

    public void ScoreClassic()
    {
        scoreClassicText.text = DataManager.ins.scoreClassic.ToString();
    }

    public void HighScoreClassic()
    {
        highScoreClassicText.text = DataManager.ins.highScoreClassic.ToString();
    }

    public void RestartGameCasual()
    {
        DataManager.ins.start_new_game = true;
        DataManager.ins.ResetDataCasual();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void RestartGameClassic()
    {
        DataManager.ins.start_new_game = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(2);
        UIController.ins.ShowClassic();
    }

    public void Menu()
    {
        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.ResetDataCasual();
    }
}
