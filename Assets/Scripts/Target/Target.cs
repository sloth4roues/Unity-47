using UnityEngine;

public class Target : MonoBehaviour
{
    public static event System.Action<GameObject> OnAnyTargetDestroyed;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Hit()
    {
        uiManager?.RegisterKill();

        OnAnyTargetDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
