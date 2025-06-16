using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtons : MonoBehaviour
{
    private void Awake()
    {
        GameSession.Instance?.ResetGameState();
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;

        GameSession.Instance?.ResetGameState();

        // Recharger la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void OnButtonClicked()
    {
        Debug.Log("BOUTON CLIQUÉ !");
    }

}
