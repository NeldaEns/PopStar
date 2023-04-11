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


    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateLevelText();
        UpdateTargetText();
        UpdateCoinText();
    }

    private void Update()
    {
        UpdateTargetText();
        UpdateLevelText();
        UpdateCoinText();
    }
    public override void OnShow()
    {
        base.OnShow();
        It1();
        It2();
        It3();
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

    public void Back()
    {
        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

    public void It1()
    {
        if (DataManager.ins.coin > 1)
        DataManager.ins.coin = DataManager.ins.coin - 2;
        DataManager.ins.SaveCoin();
        UpdateCoinText();
    }

    public void It2()
    {
        if (DataManager.ins.coin > 2)
        DataManager.ins.coin = DataManager.ins.coin - 3;
        DataManager.ins.SaveCoin();
        UpdateCoinText();
    }

    public void It3()
    {
        if (DataManager.ins.coin > 3)
        DataManager.ins.coin = DataManager.ins.coin - 4;
        DataManager.ins.SaveCoin();
        UpdateCoinText();
    }
}
