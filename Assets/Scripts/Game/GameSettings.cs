using UnityEngine;

public enum GameMode
{
    TimeAttack,  // Objectif fixe en temps limité
    Endless      // Cible infinie, score illimité
}

[CreateAssetMenu(fileName = "GameSettings", menuName = "Unit47/Game Settings")]
public class GameSettings : ScriptableObject
// ScriptableObject pour créer plusieurs configurations dans l'inspecteur.
{
    [Header("Mode de jeu actif")]
    public GameMode currentGameMode = GameMode.TimeAttack;

    [Header("Paramètres communs")]
    public GameObject targetPrefab;

    [Header("Time Attack")]
    public int timeAttackTargetCount = 30;
    public int timeAttackMaxSimultaneousTargets = 3;
    public float timeAttackDuration = 30f;

    [Header("Endless Mode")]
    public float endlessTimeBonusPerKill = 1f;
}
