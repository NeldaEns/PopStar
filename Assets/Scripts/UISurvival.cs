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
    public Button it1;
    public Button it2;
    public Button it3;

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
        if (!GameController.instance.isUsingIT1)
        {
            if (DataManager.ins.coin > 1)
            {
                selectIT1.SetActive(true);
                AudioManager.ins.PlaySFX("click");
                GameController.instance.useIt1 = true;
                it2.enabled = false;
                it3.enabled = false;
            }
        }
        else
        {
            selectIT1.SetActive(false);
            AudioManager.ins.PlaySFX("click");
            GameController.instance.useIt1 = false;
            it2.enabled = true;
            it3.enabled = true;
        }
        GameController.instance.isUsingIT1 = !GameController.instance.isUsingIT1;
    }

    public void It2()
    {
        if (!GameController.instance.isUsingIT2)
        {
            if (DataManager.ins.coin > 2)
            {
                selectIT2.SetActive(true);
                AudioManager.ins.PlaySFX("click");
                GameController.instance.useIt2 = true;
                it1.enabled = false;
                it3.enabled = false;
            }
        }
        else
        {
            selectIT2.SetActive(false);
            AudioManager.ins.PlaySFX("click");
            GameController.instance.useIt2 = false;
            it1.enabled = true;
            it3.enabled = true;
        }
        GameController.instance.isUsingIT2 = !GameController.instance.isUsingIT2;
    }

    public void It3()
    {
        if (!GameController.instance.isUsingIT3)
        {
            if (DataManager.ins.coin > 3)
            {
                selectIT3.SetActive(true);
                AudioManager.ins.PlaySFX("click");
                GameController.instance.useIt3 = true;
                it1.enabled = false;
                it2.enabled = false;
            }
        }
        else
        {
            selectIT3.SetActive(false);
            AudioManager.ins.PlaySFX("click");
            GameController.instance.useIt3 = false;
            it1.enabled = true;
            it2.enabled = true;
        }
        GameController.instance.isUsingIT3 = !GameController.instance.isUsingIT3;
    }
}
