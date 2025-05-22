using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera playerCam;
    public float range = 50f;
    public LayerMask hitLayers;
    public AudioSource shootSound;

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        // Dessine le rayon pendant 1s pour debug
        Debug.Log("AUO");
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.red, 1f);

        // Joue le son si présent
        if (shootSound)
            shootSound.Play();

        // Raycast pour détecter la cible
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range, hitLayers))
        {
            Debug.Log("Touché : " + hit.collider.name);

            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject); // OU réduire les PV
            }
        }
    }
}
