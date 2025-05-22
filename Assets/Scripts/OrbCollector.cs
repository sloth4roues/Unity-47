using UnityEngine;
using UnityEngine.InputSystem;

public class OrbCollector : MonoBehaviour
{
    public float interactRange = 2f;
    public LayerMask OrbLayer;

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryCollectOrb();
        }
    }

    void TryCollectOrb()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactRange);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Orb"))
            {
                Destroy(hit.gameObject);
                return;
            }
        }
    }
}
