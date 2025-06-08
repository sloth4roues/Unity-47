using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Goal UI")]
    public TextMeshProUGUI goalText;
    private int currentKills = 0;
    public int targetKills = 100;

    [Header("Timer UI")]
    public TextMeshProUGUI timerText;
    public float totalTime = 120f;
    private float remainingTime;

    [Header("Ammo UI")]
    public TextMeshProUGUI ammoText;

    [Header("FPS UI")]
    public TextMeshProUGUI fpsText;
    private float deltaTime;

    [Header("Game End Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Fin de jeu")]
    public EndGameHandler endGameHandler;


    private bool gameEnded = false;

    void Start()
    {
        remainingTime = totalTime;

        if (goalText != null)
            UpdateGoalText();
    }

    void Update()
    {
        if (gameEnded) return;

        // Timer
        if (timerText != null)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                remainingTime = 0;
                UpdateTimerText();
                EndGame(false); // Défaite
                return;
            }

            UpdateTimerText();
        }

        // FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }

    public void RegisterKill()
    {
        if (goalText == null) return;

        currentKills++;
        UpdateGoalText();

        if (currentKills >= targetKills && !gameEnded)
        {
            EndGame(true); 
        }
    }


    void UpdateGoalText()
    {
        int killsLeft = Mathf.Max(0, targetKills - currentKills);
        goalText.text = $"Kill {killsLeft} bots";
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
    public void UpdateAmmo(int current, int max)
    {
        if (ammoText != null)
            ammoText.text = $"{current} / {max}";
    }
    void EndGame(bool win)
    {
        gameEnded = true;

        if (win && winPanel != null)
            winPanel.SetActive(true);
        else if (!win && losePanel != null)
            losePanel.SetActive(true);

        // Ralentir le temps au lieu de le geler
        Time.timeScale = 0.01f;

        if (endGameHandler != null)
            endGameHandler.TriggerEndGameView();
    }
    public void AddTime(float amount)
    {
        if (!gameEnded)
            remainingTime += amount;
    }


}
