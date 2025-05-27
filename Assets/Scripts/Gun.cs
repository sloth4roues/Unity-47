using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Gun : MonoBehaviour
{
    [Header("Camera & Tir")]
    public Camera playerCam;
    public float range = 50f;
    public LayerMask shootableLayers; // Renommé pour plus de clarté

    [Header("Effets visuels et sonores")]
    public AudioSource shootSound;
    public ParticleSystem muzzleFlash;
    public HitEffectManager hitEffectManager;

    [Header("Munitions")]
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

        // Debug visuel du rayon
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.red, 1f);

        // Effet visuel du tir
        if (muzzleFlash)
            muzzleFlash.Play();

        // Son du tir
        if (shootSound)
            shootSound.Play();

        // Raycast pour détecter un impact sur les layers spécifiés
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range, shootableLayers))
        {
            // Si c'est une cible destructible
            var target = hit.collider.GetComponent<Target>();
            if (target != null)
                target.Hit();

            // Jouer l'effet visuel correspondant
            if (hitEffectManager != null)
                hitEffectManager.SpawnHitEffect(hit);
        }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);
    }
}
