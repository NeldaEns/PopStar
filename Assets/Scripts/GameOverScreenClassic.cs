using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenClassic : UIScreenBase
{
    public Text scoreClassicText;
    public Text highScoreClassicText;

    public override void OnShow()
    {
        base.OnShow();
        ScoreClassic();
        HighScoreClassic();
    }
    public void ScoreClassic()
    {
        scoreClassicText.text = DataManager.ins.scoreClassic.ToString();
    }

    public void HighScoreClassic()
    {
        highScoreClassicText.text = DataManager.ins.highScoreClassic.ToString();
    }

    public void RestartGameClassic()
    {
        DataManager.ins.start_new_game_classic = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(1);
        UIController.ins.ShowClassic();
    }

    public void Menu()
    {
        Hide();
        AudioManager.ins.PlaySFX("click1");
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
        DataManager.ins.ResetDataClassic();
    }
}
