using UnityEngine;

public class Target : MonoBehaviour
{
    public static event System.Action<GameObject> OnAnyTargetDestroyed;

    public void Hit()
    {
        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
            ui.RegisterKill();

        OnAnyTargetDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
