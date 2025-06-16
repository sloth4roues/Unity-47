using UnityEngine;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;

    public int finalScore = 0;
    public float timeElapsed = 0f;
    public GameMode modePlayed;

    public bool gameEnded = false; // ← AJOUT OBLIGATOIRE

    void Awake()
    {
        var inputs = FindObjectsOfType<PlayerInput>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndSession()
    {
        gameEnded = true;
    }

    public void ResetGameState()
    {
        gameEnded = false;
    }

}
