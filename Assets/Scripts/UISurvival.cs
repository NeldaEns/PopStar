using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UISurvival : UIScreenBase
{
    public Text txtScore;
    public Text txtHighScore;
    public Text txtCoin;
    public Text txtCurrentTime;
    public GameObject selectIT1;
    public GameObject selectIT2;
    public GameObject selectIT3;

    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateCoinText();
        UpdateTimeText();
    }

    public override void OnShow()
    {
        base.OnShow();
        It1();
        It2();
        It3();
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateCoinText();
        UpdateTimeText();
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.scoreSurvival.ToString();
    }

    public void UpdateHighScoreText()
    {
        txtHighScore.text = DataManager.ins.highScoreSurvival.ToString();
    }

    public void UpdateCoinText()
    {
        txtCoin.text = DataManager.ins.coin.ToString();
    }

    public void UpdateTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(DataManager.ins.currentTime);
        txtCurrentTime.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void Back()
    {
        DataManager.ins.timeActive = false;
        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }

    public void It1()
    {
        if (DataManager.ins.coin > 1)
        {
            selectIT1.SetActive(true);
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
            selectIT2.SetActive(true);
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
            selectIT3.SetActive(true);
            DataManager.ins.coin = DataManager.ins.coin - 4;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt3 = true;
        }
    }
}
