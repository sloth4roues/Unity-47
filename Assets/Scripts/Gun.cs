using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Gun : MonoBehaviour
{
    public Camera playerCam;
    public float range = 50f;
    public LayerMask hitLayers;
    public AudioSource shootSound;
    public ParticleSystem muzzleFlash;

    [Header("Ammunition")]
    public int maxAmmo = 20;
    public int currentAmmo;

    public static event Action<int, int> OnAmmoChanged;

    void Start()
    {
        currentAmmo = maxAmmo;
        OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed || currentAmmo <= 0)
            return;

        Shoot();
    }

    private void Shoot()
    {
        currentAmmo--;
        OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.red, 1f);

        if (muzzleFlash)
            muzzleFlash.Play();

        if (shootSound)
            shootSound.Play();

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range, hitLayers))
        {
            var target = hit.collider.GetComponent<Target>();
            if (target != null)
                target.Hit();
        }
    }
}
