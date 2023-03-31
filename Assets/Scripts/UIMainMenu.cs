using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : UIScreenBase
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }
    public void Continue()
    {

    }

    public override void OnShow()
    {
        base.OnShow();
    }
    public void Back()
    {
        Application.Quit();
    }
    public override void Hide()
    {
        base.Hide();
        Debug.Log("chay tiep");
    }
}
