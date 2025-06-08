using UnityEngine;

public class TargetSurvival : MonoBehaviour
{
    public SurvivalSpawner survivalSpawner;

    public void Hit()
    {
        if (survivalSpawner != null)
        {
            survivalSpawner.TargetDestroyed(gameObject);
        }
        else
        {
            Debug.LogWarning("SurvivalSpawner non assigné !");
        }
    }
}
