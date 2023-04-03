using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICasual : UIScreenBase
{
    public Text txtScore;
    public Text txtLevel;
    public Text txtHighScore;
    public Text txtTarget;
    public Text txtCoin;

    public override void OnShow()
    {
        base.OnShow();
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateLevelText();
        UpdateTargetText();
        UpdateCoinText();
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.score.ToString();
    }

    public void UpdateHighScoreText()
    {
        txtHighScore.text = DataManager.ins.highScore.ToString();
    }

    public void UpdateLevelText()
    {
        txtLevel.text = DataManager.ins.level.ToString();
    }

    public void UpdateTargetText()
    {   
        txtTarget.text = DataManager.ins.target.ToString();
    }
    public void UpdateCoinText()
    {
        txtCoin.text = DataManager.ins.coin.ToString();
    }

    public void Clean()
    {
        PlayerPrefs.DeleteAll();

    }

    public void Back()
    {
        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

}
