using UnityEngine;

public class Target : MonoBehaviour
{
    public static event System.Action<GameObject> OnAnyTargetDestroyed;


    public void Hit()
    {
        FindObjectOfType<UIManager>()?.RegisterKill();
        FindObjectOfType<GameManager>()?.RegisterTargetDestroyed();
        OnAnyTargetDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}