using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
    public GameObject crosshair;

    private bool gameEnded = false;
    private EventSystem eventSystem;

    void Start()
    {
        GameSettings settings = FindObjectOfType<SpawnBots>()?.settings;
        if (settings != null && settings.currentGameMode == GameMode.TimeAttack)
        {
            targetKills = settings.timeAttackTargetCount;
            totalTime = settings.timeAttackDuration;
        }

        remainingTime = totalTime;
        UpdateGoalText();
        eventSystem = EventSystem.current;
    }

    void Update()
    {
        if (gameEnded) return;

        UpdateTimer();
        UpdateFPS();
    }

    private void UpdateTimer()
    {
        if (timerText == null) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0;
            UpdateTimerText();
            EndGame(false);
            return;
        }

        UpdateTimerText();
    }

    private void UpdateFPS()
    {
        if (fpsText == null) return;

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = $"{Mathf.CeilToInt(fps)} FPS";
    }

    private void SelectFirstButton(GameObject panel)
    {
        if (eventSystem == null || panel == null) return;

        Button firstButton = panel.GetComponentInChildren<Button>();
        if (firstButton != null)
            eventSystem.SetSelectedGameObject(firstButton.gameObject);
    }

    public void RegisterKill()
    {
        if (goalText == null) return;

        currentKills++;
        UpdateGoalText();

        if (currentKills >= targetKills && !gameEnded)
            EndGame(true);
    }

    private void UpdateGoalText()
    {
        if (goalText == null) return;

        if (targetKills <= 0)
        {
            goalText.text = "";
            return;
        }

        int killsLeft = Mathf.Max(0, targetKills - currentKills);
        goalText.text = $"Kill {killsLeft} bots";
    }

    private void UpdateTimerText()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void UpdateAmmo(int current, int max)
    {
        if (ammoText != null)
            ammoText.text = $"{current} / {max}";
    }

    private void EndGame(bool win)
    {
        gameEnded = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameSession.Instance != null)
            GameSession.Instance.gameEnded = true;

        crosshair.SetActive(false);

        GameObject panel = win ? winPanel : losePanel;
        if (panel != null)
        {
            panel.SetActive(true);
            SelectFirstButton(panel);
        }
    }

    public void AddTime(float amount)
    {
        if (!gameEnded)
            remainingTime += amount;
    }
}
