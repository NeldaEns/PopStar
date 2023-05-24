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
    public GameObject panel;


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
        txtScore.text = DataManager.ins.scoreCasual.ToString();
    }

    public void UpdateHighScoreText()
    {
        txtHighScore.text = DataManager.ins.highScoreCasual.ToString();
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
        AudioManager.ins.PlaySFX("click1");
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

    public void It1()
    {
        if (DataManager.ins.coin > 1)
        {
            AudioManager.ins.PlaySFX("click");
            DataManager.ins.coin = DataManager.ins.coin - 2;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt1 = true;
        }
    }

    public void It2()
    {
        if (DataManager.ins.coin > 2)
        {
            AudioManager.ins.PlaySFX("click");
            DataManager.ins.coin = DataManager.ins.coin - 3;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt2 = true;         
        }       
    }

    public void It3()
    {
        if (DataManager.ins.coin > 3)
        {
            AudioManager.ins.PlaySFX("click");
            DataManager.ins.coin = DataManager.ins.coin - 4;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt3 = true;
        }
    }
}
