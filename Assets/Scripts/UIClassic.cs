using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIClassic : UIScreenBase
{
    public Text txtScore;
    public Text txtHighScore;
    public Text txtCoin;

    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
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
        UpdateCoinText();
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.scoreClassic.ToString();
    }

    public void UpdateHighScoreText()
    {
        txtHighScore.text = DataManager.ins.highScoreClassic.ToString();
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
        {
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
            DataManager.ins.coin = DataManager.ins.coin - 4;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt3 = true;
        }
    }
}
