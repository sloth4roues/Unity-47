using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Gun : MonoBehaviour
{
    [Header("Camera & Tir")]
    public Camera playerCam;
    public float range = 50f;
    public LayerMask shootableLayers;


    [Header("Effets visuels")]
    public AudioSource shootSound;
    public ParticleSystem muzzleFlash;
    public HitEffectManager hitEffectManager;

    [Header("Impact Sound")]
    public SoundSpawner destroyableSoundSpawner;


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

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.red, 1f);

        if (muzzleFlash)
            muzzleFlash.Play();

        if (shootSound)
            shootSound.Play();

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, range, shootableLayers))
        {
            var target = hit.collider.GetComponent<Target>();
            if (target != null)
                target.Hit();

            if (hit.collider.CompareTag("DestroyableTag"))
            {
                if (destroyableSoundSpawner != null)
                    destroyableSoundSpawner.PlaySoundAt(hit.point);

                Destroy(hit.collider.gameObject);
            }

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
