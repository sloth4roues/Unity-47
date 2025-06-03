using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject panelMainMenu;
    public GameObject panelGameModeSelect;

    [Header("Scene Names")]
    public string level1SceneName = "Level1";
    public string playgroundSceneName = "Playground";

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        panelMainMenu.SetActive(true);
        panelGameModeSelect.SetActive(false);
    }

    public void ShowGameModeSelect()
    {
        panelMainMenu.SetActive(false);
        panelGameModeSelect.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void LoadPlayground()
    {
        SceneManager.LoadScene(playgroundSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
