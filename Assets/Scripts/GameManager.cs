using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalTargets = 10;
    private int currentDestroyed = 0;

    public GameObject winPanel;
    public GameObject losePanel;

    public float gameDuration = 60f;
    private float timer;

    private bool gameEnded = false;

    void Start()
    {
        timer = gameDuration;
        Time.timeScale = 1;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            EndGame(false);
        }
    }

    public void RegisterTargetDestroyed()
    {
        if (gameEnded) return;

        currentDestroyed++;
        if (currentDestroyed >= totalTargets)
        {
            EndGame(true);
        }
    }

    void EndGame(bool won)
    {
        gameEnded = true;
        Time.timeScale = 0;
        if (won)
            winPanel.SetActive(true);
        else
            losePanel.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
