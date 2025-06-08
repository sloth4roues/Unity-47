using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    [Header("Mode de jeu")]
    public GameMode gameMode = GameMode.TimeAttack;

    [Header("Prefab de la cible")]
    public GameObject targetPrefab;

    [Header("Zone de spawn")]
    public float rangeX = 5f;
    public float rangeY = 3f;
    public float fixedZ = 10f;

    [Header("Paramètres TimeAttack")]
    public int maxActiveTargets = 3;
    public int totalTargetsToSpawn = 30;

    [Header("Paramètres Endless")]
    public bool addTimeOnKill = true;
    public float timeToAddPerKill = 1f;

    private List<GameObject> activeTargets = new List<GameObject>();
    private int totalSpawned = 0;

    void OnEnable()
    {
        Target.OnAnyTargetDestroyed += HandleTargetDestroyed;
    }

    void OnDisable()
    {
        Target.OnAnyTargetDestroyed -= HandleTargetDestroyed;
    }

    void Start()
    {
        if (gameMode == GameMode.TimeAttack)
        {
            for (int i = 0; i < maxActiveTargets; i++)
                SpawnOne();
        }
        else if (gameMode == GameMode.Endless)
        {
            SpawnOne(); // Une seule cible au début
        }
    }

    void HandleTargetDestroyed(GameObject destroyedTarget)
    {
        if (activeTargets.Contains(destroyedTarget))
            activeTargets.Remove(destroyedTarget);

        if (gameMode == GameMode.TimeAttack)
        {
            totalSpawned++;
            if (totalSpawned < totalTargetsToSpawn)
                SpawnOne();
        }
        else if (gameMode == GameMode.Endless)
        {
            FindObjectOfType<UIManager>()?.AddTime(timeToAddPerKill);
            SpawnOne(); // Toujours respawn une cible
        }
    }

    void SpawnOne()
    {
        if (targetPrefab == null) return;

        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-rangeX, rangeX),
            Random.Range(-rangeY, rangeY),
            fixedZ
        );

        GameObject newTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        activeTargets.Add(newTarget);
    }
}
