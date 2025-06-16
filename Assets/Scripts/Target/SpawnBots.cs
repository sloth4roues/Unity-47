using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    [Header("Configuration")]
    public GameSettings settings;

    private List<GameObject> activeTargets = new List<GameObject>();
    private int totalSpawned = 0;

    void Start()
    {
        if (settings == null || settings.targetPrefab == null)
        {
            Debug.LogError("GameSettings ou targetPrefab manquant.");
            return;
        }

        if (settings.currentGameMode == GameMode.TimeAttack)
        {
            for (int i = 0; i < settings.timeAttackMaxSimultaneousTargets; i++)
                SpawnOne();
        }
        else if (settings.currentGameMode == GameMode.Endless)
        {
            SpawnOne();
        }
    }

    void HandleTargetDestroyed(GameObject destroyedTarget)
    {
        if (activeTargets.Contains(destroyedTarget))
            activeTargets.Remove(destroyedTarget);

        if (settings.currentGameMode == GameMode.TimeAttack)
        {
            totalSpawned++;
            if (totalSpawned < settings.timeAttackTargetCount)
                SpawnOne();
        }
        else if (settings.currentGameMode == GameMode.Endless)
        {
            FindObjectOfType<UIManager>()?.AddTime(settings.endlessTimeBonusPerKill);
            SpawnOne();
        }
    }

    void SpawnOne()
    {
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-5f, 5f), // A PARAMETRER
            Random.Range(-3f, 3f),// A PARAMATRER
            10f
        );

        GameObject newTarget = Instantiate(settings.targetPrefab, spawnPos, Quaternion.identity);
        activeTargets.Add(newTarget);
    }
    void OnEnable()
    {
        Target.OnAnyTargetDestroyed += HandleTargetDestroyed;
    }

    void OnDisable()
    {
        Target.OnAnyTargetDestroyed -= HandleTargetDestroyed;
    }


    void OnDestroy()
    {
        Target.OnAnyTargetDestroyed -= HandleTargetDestroyed;
    }

}
