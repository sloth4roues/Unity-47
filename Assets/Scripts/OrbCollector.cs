using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbCollector : MonoBehaviour
{
    public float interactRange = 2f;
    public LayerMask OrbLayer;

    [Header("UltOrb")]
    public int maxOrb = 20;
    public int currentOrb = 0;

    public static event Action<int, int> OnOrbChanged;

    void Start()
    {
        currentOrb = 0;
        OnOrbChanged?.Invoke(currentOrb, maxOrb);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryCollectOrb();
        }
    }

    void TryCollectOrb()
    {
        if (currentOrb >= maxOrb)
            return;

        Collider[] hits = Physics.OverlapSphere(transform.position, interactRange, OrbLayer);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Orb"))
            {
                currentOrb++;
                OnOrbChanged?.Invoke(currentOrb, maxOrb); // MAJ UI
                Destroy(hit.gameObject);
                return;
            }
        }
    }

}
