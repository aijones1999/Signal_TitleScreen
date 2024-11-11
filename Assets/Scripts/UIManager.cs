using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject openingScreen;
    public GameObject logoScreen;
    public GameObject mainMenu;
    public GameObject optionsScreen;
    public GameObject creditsScreen;

    private GameObject currentScreen;

    void Start()
    {
        // Start on the OpeningScreen
        if (openingScreen != null)
        {
            ShowScreen(openingScreen);
        }
    }

    void Update()
    {
        // Transition from OpeningScreen to LogoScreen on spacebar press
        if (currentScreen == openingScreen && Input.GetKeyDown(KeyCode.Space))
        {
            GoToLogoScreen();
        }

        // Transition from LogoScreen to MainMenu on left mouse click or Enter key
        if (currentScreen == logoScreen && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            GoToMainMenu();
        }

        // Transition from MainMenu to OptionsScreen on O key
        if (currentScreen == mainMenu && Input.GetKeyDown(KeyCode.O))
        {
            GoToOptionsScreen();
        }

        // Transition from MainMenu to CreditsScreen on C key
        if (currentScreen == mainMenu && Input.GetKeyDown(KeyCode.C))
        {
            GoToCreditsScreen();
        }

        // Transition from OptionsScreen back to MainMenu on Escape key
        if (currentScreen == optionsScreen && Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }

        // Transition from CreditsScreen back to MainMenu on Escape key
        if (currentScreen == creditsScreen && Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    // Function to show a specific screen and hide the current one
    public void ShowScreen(GameObject screenToShow)
    {
        // If a screen is currently active, disable it
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
        }

        // Enable the new screen and update the current screen reference
        screenToShow.SetActive(true);
        currentScreen = screenToShow;
    }

    // Functions for each screen transition
    public void GoToLogoScreen()
    {
        ShowScreen(logoScreen);
    }

    public void GoToMainMenu()
    {
        ShowScreen(mainMenu);
    }

    public void GoToOptionsScreen()
    {
        ShowScreen(optionsScreen);
    }

    public void GoToCreditsScreen()
    {
        ShowScreen(creditsScreen);
    }

    public void BackToMainMenu()
    {
        ShowScreen(mainMenu);
    }
}




