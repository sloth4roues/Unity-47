using UnityEngine;

public enum GameMode
{
    TimeAttack,  // Objectif fixe en temps limit�
    Endless      // Cible infinie, score illimit�
}

[CreateAssetMenu(fileName = "GameSettings", menuName = "Unit47/Game Settings")]
public class GameSettings : ScriptableObject
// ScriptableObject pour cr�er plusieurs configurations dans l'inspecteur.
{
    [Header("Mode de jeu actif")]
    public GameMode currentGameMode = GameMode.TimeAttack;

    [Header("Param�tres communs")]
    public GameObject targetPrefab;

    [Header("Time Attack")]
    public int timeAttackTargetCount = 30;
    public int timeAttackMaxSimultaneousTargets = 3;
    public float timeAttackDuration = 30f;

    [Header("Endless Mode")]
    public float endlessTimeBonusPerKill = 1f;
}
