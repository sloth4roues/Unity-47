using UnityEngine;

public class SurvivalSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Vector2 spawnRangeX = new Vector2(-5f, 5f);
    public Vector2 spawnRangeY = new Vector2(1f, 3f);
    public float fixedZ = 20f;

    private GameObject currentTarget;

    public UIManager uiManager; // référence au timer et score

    void Start()
    {
        SpawnTarget();
    }

    public void OnTargetDestroyed()
    {
        // Rajoute du temps au timer
        uiManager.AddTime(0.5f);

        // Incrémente le score
        uiManager.RegisterKill(); // ou RegisterScore(), si tu veux séparer

        // Respawn une nouvelle cible
        SpawnTarget();
    }

    void SpawnTarget()
    {
        if (currentTarget != null) return;

        Vector3 spawnPos = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            Random.Range(spawnRangeY.x, spawnRangeY.y),
            fixedZ
        );

        currentTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        TargetSurvival targetScript = currentTarget.GetComponent<TargetSurvival>();
        targetScript.survivalSpawner = this;
    }

    public void TargetDestroyed(GameObject target)
    {
        if (target == currentTarget)
        {
            Destroy(currentTarget);
            currentTarget = null;
            OnTargetDestroyed();
        }
    }
}
