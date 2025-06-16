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

    private bool gameEnded = false;

    void Start()
    {

        GameSettings settings = FindObjectOfType<SpawnBots>()?.settings;
        if (settings != null && settings.currentGameMode == GameMode.TimeAttack)
            targetKills = settings.timeAttackTargetCount;
            totalTime = settings.timeAttackDuration;

        remainingTime = totalTime;
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

    void SelectFirstButton(GameObject panel)
    {
        Button firstButton = panel.GetComponentInChildren<Button>();
        if (firstButton != null)
            EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
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
        if (goalText == null) return;

        if (targetKills <= 0)
        {
            goalText.text = ""; // Objectif facultatif
            return;
        }

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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        if (GameSession.Instance != null)
            GameSession.Instance.gameEnded = true;

        //Time.timeScale = 0.01f;

        if (win && winPanel != null)
        {
            winPanel.SetActive(true);
            SelectFirstButton(winPanel);
        }
        else if (!win && losePanel != null)
        {
            losePanel.SetActive(true);
            SelectFirstButton(losePanel);
        }
    }




    public void AddTime(float amount)
    {
        if (!gameEnded)
            remainingTime += amount;
    }

}
