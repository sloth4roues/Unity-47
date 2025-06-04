using System.Collections.Generic;
using UnityEngine;

public class SpawnBots : MonoBehaviour
{
    [Header("Prefab de la cible")]
    public GameObject targetPrefab;

    [Header("Zone de spawn")]
    public float rangeX = 5f;
    public float rangeY = 3f;
    public float fixedZ = 10f;

    [Header("Paramètres")]
    public int maxActiveTargets = 3;

    private List<GameObject> activeTargets = new List<GameObject>();

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
        for (int i = 0; i < maxActiveTargets; i++)
            SpawnOne();
    }

    void HandleTargetDestroyed(GameObject destroyedTarget)
    {
        if (activeTargets.Contains(destroyedTarget))
            activeTargets.Remove(destroyedTarget);

        SpawnOne(); // Remplacer celle qui vient d’être détruite
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
