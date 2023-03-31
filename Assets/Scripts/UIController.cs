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
    public GameObject mainCamera;

    private void Awake()
    {
        if(ins != null)
        {
            Destroy(gameObject);
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
        currentScreen = Instantiate(mainMenu, transform).GetComponent<UIMainMenu>();
    }

    public void ShowCasual()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(casualPanel, transform).GetComponent<UICasual>();
    }

    public void ShowMenu()
    {
        Destroy(currentScreen.gameObject);
        currentScreen = Instantiate(mainMenu, transform).GetComponent<UIMainMenu>();
        Destroy(mainCamera);
    }
}
