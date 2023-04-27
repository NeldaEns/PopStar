using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : UIScreenBase
{

    public void StartCasual()
    {
        if(DataManager.ins.scoreCasual == 0)
        {
            if (DataManager.ins.highScoreCasual == 0)
            {
                DataManager.ins.start_new_game_casual = true;
                DataManager.ins.StartDataCasual();
                SceneManager.LoadScene(1);
                UIController.ins.ShowCasual();
            }
            else
            {
                RestartCasual();
            }
        }     
    }

    public void StartClassic()
    {
        if(DataManager.ins.scoreClassic == 0)
        {
            if(DataManager.ins.highScoreClassic == 0)
            {
                DataManager.ins.start_new_game_classic = true;
                DataManager.ins.StartDataClassic();
                SceneManager.LoadScene(2);
                UIController.ins.ShowClassic();
            }
            else
            {
                RestartClassic();
            }
        }
    }
    public void RestartCasual()
    {
        DataManager.ins.start_new_game_casual = true;
        DataManager.ins.ResetDataCasual();
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual();
    }

    public void RestartClassic()
    {
        DataManager.ins.start_new_game_classic = true;
        DataManager.ins.ResetDataClassic();
        SceneManager.LoadScene(2);
        UIController.ins.ShowClassic();
    }
    public void ContinueCasual()
    {
        DataManager.ins.start_new_game_casual = false;
        SceneManager.LoadScene(1);
        UIController.ins.ShowCasual(); 
    }

    public void ContinueClassic()
    {
        DataManager.ins.start_new_game_classic = false; 
        SceneManager.LoadScene(2);
        UIController.ins.ShowClassic();
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
