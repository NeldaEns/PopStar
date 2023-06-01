using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController ins;
    [HideInInspector]
    public UIScreenBase currentScreen;
    public GameObject mainMenu;
    public GameObject casualPanel;
    public GameObject classicPanel;
    public GameObject survivalPanel;
    public GameObject mainCameraPrefabs;
    public GameOverScreenCasual casualGameOverScreen;
    public GameOverScreenClassic classicGameOverScreen;
    public SurvivalGameOverScreen survivalGameOverScreen;

    private void Awake()
    {
        GameObject mainCamera = Instantiate(mainCameraPrefabs);
        if (ins != null)
        {
            Destroy(gameObject);
            Destroy(mainCamera);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(mainCamera);
        }
    }

    private void Start()
    {
        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;       
        currentScreen = Instantiate(mainMenu, transform).GetComponent<UIMainMenu>();
    }

    public void ShowCasual()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gamestart");
        currentScreen = Instantiate(casualPanel, transform).GetComponent<UICasual>();
    }

    public void ShowClassic()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gamestart");
        currentScreen = Instantiate(classicPanel, transform).GetComponent<UIClassic>();
    }

    public void ShowSurvival()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gamestart");
        currentScreen = Instantiate(survivalPanel, transform).GetComponent<UISurvival>();
    }

    public void ShowMenu()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(mainMenu, transform).GetComponent<UIMainMenu>();
    }

    public void ShowGameOverCasual()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gameover");
        currentScreen = Instantiate(casualGameOverScreen, transform).GetComponent<GameOverScreenCasual>();
    }

    public void ShowGameOverClassic()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gameover");
        currentScreen = Instantiate(classicGameOverScreen, transform).GetComponent<GameOverScreenClassic>();    
    }

    public void ShowGameOverSurvival()
    {
        Destroy(currentScreen.gameObject);
        AudioManager.ins.PlaySFX("gameover");
        currentScreen = Instantiate(survivalGameOverScreen, transform).GetComponent<SurvivalGameOverScreen>();
    }
  
}   
