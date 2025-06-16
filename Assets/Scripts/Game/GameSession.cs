using UnityEngine;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }

    public int finalScore = 0;
    public float timeElapsed = 0f;
    public GameMode modePlayed;

    public bool gameEnded = false;

    private void Awake()
    {
        Instance = this;
        Debug.Log("GameSession (NON persistante) créée");
    }

    private void Update()
    {
        Debug.Log("PlayerInput actifs : " + FindObjectsOfType<PlayerInput>().Length);

    }

    public void EndSession()
    {
        gameEnded = true;
    }

    public void ResetGameState()
    {
        gameEnded = false;
        finalScore = 0;
        timeElapsed = 0f;
        modePlayed = default;
    }
}
