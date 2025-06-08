using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject panelMainMenu;
    public GameObject panelGameModeSelect;
    public GameObject panelLevelsSelect;

    [Header("Scene Names")]
    public string level1SceneName = "Level1";
    public string level2SceneName = "Level2";
    public string playgroundSceneName = "Playground";

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        panelLevelsSelect.SetActive(false);
        panelMainMenu.SetActive(true); // ici
        panelGameModeSelect.SetActive(false);
    }

    public void ShowGameModeSelect()
    {
        panelMainMenu.SetActive(false);
        panelLevelsSelect.SetActive(false);
        panelGameModeSelect.SetActive(true); // ici
    }
    public void ShowLevelsSelect()
    {
        panelGameModeSelect.SetActive(false);
        panelMainMenu.SetActive(false);
        panelLevelsSelect.SetActive(true); // ici
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2SceneName);
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
