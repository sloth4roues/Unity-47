using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtons : MonoBehaviour
{
    public void ReplayLevel()
    {
        Debug.Log("Replay - ActiveScene: " + SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Debug.Log("TimeScale: " + Time.timeScale);

        // Réinitialiser l'état de la game
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetGameState();
        }
        else
        {
            Debug.LogWarning("GameSession introuvable pour reset.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
