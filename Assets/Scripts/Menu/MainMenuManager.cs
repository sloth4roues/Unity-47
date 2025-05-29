using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string sceneToLoad = "Level1";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
