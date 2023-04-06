using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : UIScreenBase
{
    public Text scoreText;

    public override void OnShow()
    {
        base.OnShow();
        Score();
    }
    public void Score()
    {
        scoreText.text = DataManager.ins.score.ToString();
    }

    public void RestartGame()
    {
        DataManager.ins.ResetData();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void Menu()
    {

        Hide();
        UIController.ins.ShowMenu();
        SceneManager.LoadScene(0);
    }
}
