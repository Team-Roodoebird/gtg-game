using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //Get menu panels to enable/disable
    [SerializeField] GameObject mainMenuPanel = null;
    [SerializeField] GameObject loadMenuPanel = null;
    [SerializeField] GameObject creditsMenuPanel = null;
    [SerializeField] GameObject settingsMenuPanel = null;
    [SerializeField] GameObject quitMenuPanel = null;

    //Keep track which state is active
    private MenuState currentMenuState;

    private void Start()
    {
        //Start with the Main Menu panel active
        currentMenuState = MenuState.Main;
    }

    //Menu choices (choices limited through enums)
    public enum MenuState
    {
        Main,
        Load,
        Credits,
        Settings,
        Quit
    }

    public void ChooseMenuToOpen(string _menuName)
    {
        switch (_menuName)
        {
            case "Main":
            case "main":
                currentMenuState = MenuState.Main;
                Debug.Log("Current menu state: Main");
                break;

            case "Load":
            case "load":
                currentMenuState = MenuState.Load;
                Debug.Log("Current menu state: Load");
                break;

            case "Credits":
            case "credits":
                currentMenuState = MenuState.Credits;
                Debug.Log("Current menu state: Credits");
                break;

            case "Settings":
            case "settings":
                currentMenuState = MenuState.Settings;
                Debug.Log("Current menu state: Settings");
                break;

            case "Quit":
            case "quit":
                currentMenuState = MenuState.Quit;
                Debug.Log("Current menu state: Quit");
                break;

            default:
                Debug.Log("Invalid menu state.");
                break;
        }
        ChangeMenuTo(currentMenuState);
    }

    public void ChangeMenuTo(MenuState _menuName)
    {
        switch (_menuName)
        {
            case MenuState.Main:
                mainMenuPanel.SetActive(true);
                loadMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                settingsMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case MenuState.Load:
                loadMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                settingsMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case MenuState.Credits:
                creditsMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                loadMenuPanel.SetActive(false);
                settingsMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case MenuState.Settings:
                settingsMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                loadMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                quitMenuPanel.SetActive(false);
                break;

            case MenuState.Quit:
                quitMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                loadMenuPanel.SetActive(false);
                creditsMenuPanel.SetActive(false);
                settingsMenuPanel.SetActive(false);
                break;
        }
    }
}