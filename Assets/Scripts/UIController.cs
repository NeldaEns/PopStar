using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController ins;
    [HideInInspector]
    public UIScreenBase currentScreen;
    public GameObject mainMenu;
    public GameObject casualPanel;
    public GameObject classicPanel;
    public GameObject mainCameraPrefabs;
    public GameOverScreen GameOverScreen;   

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
        currentScreen = Instantiate(casualPanel, transform).GetComponent<UICasual>();
    }

    public void ShowClassic()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(classicPanel, transform).GetComponent<UIClassic>();
    }

    public void ShowMenu()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(mainMenu, transform).GetComponent<UIMainMenu>();
    }

    public void ShowGameOver()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(GameOverScreen, transform).GetComponent<GameOverScreen>();
    }
}   
