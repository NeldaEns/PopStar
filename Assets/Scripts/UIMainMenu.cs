using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : UIScreenBase
{

    public void StartCasual()
    {
        if(DataManager.ins.score == 0)
        {
            if(DataManager.ins.highScore == 0)
            {
                DataManager.ins.start_new_game = true;
                DataManager.ins.StartData();
                SceneManager.LoadScene(1);
                UIController.ins.ShowCasual();
            }
             else
            {
                RestartCasual();
            }
        }     
    }
    public void RestartCasual()
    {
        DataManager.ins.start_new_game = true;
        DataManager.ins.ResetData();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }
    public void ContinueCasual()
    {
        DataManager.ins.start_new_game = false;
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual(); 
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
