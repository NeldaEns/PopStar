using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIClassic : UIScreenBase
{
    public Text txtScore;
    public Text txtLevel;
    public Text txtHighScore;
    public Text txtTarget;
    public Text txtCoin;
    public Text txtLevel1;
    public Text txtTarget1;
    public GameObject panel;
    public GameObject selectIT1;
    public GameObject selectIT2;
    public GameObject selectIT3;

    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateLevelText();
        UpdateTargetText();
        UpdateCoinText();
        ShowPanel();
    }

    private void Update()
    {
        UpdateTargetText();
        UpdateLevelText();
        UpdateCoinText();
        ShowPanel();
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
        ShowPanel();
    }

    public void UpdateScoreText()
    {
        txtScore.text = DataManager.ins.scoreClassic.ToString();
    }

    public void UpdateHighScoreText()
    {
        txtHighScore.text = DataManager.ins.highScoreClassic.ToString();
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

    public void ShowPanel()
    {       
        txtLevel1.text = txtLevel.text;
        txtTarget1.text = txtTarget.text;
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
            selectIT1.SetActive(true);
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
            selectIT2.SetActive(true);
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
            selectIT3.SetActive(true);
            AudioManager.ins.PlaySFX("click");
            DataManager.ins.coin = DataManager.ins.coin - 4;
            DataManager.ins.SaveCoin();
            UpdateCoinText();
            GameController.instance.useIt3 = true;
        }
    }
}
