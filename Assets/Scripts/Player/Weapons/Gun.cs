using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Gun : MonoBehaviour
{
    [Header("Références")]
    public Camera playerCam;
    public Transform muzzlePoint;

    [Header("Tir")]
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

    [Header("Traînée visuelle")]
    public GameObject bulletTrailPrefab;

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

        if (muzzleFlash)
            muzzleFlash.Play();

        if (shootSound)
            shootSound.Play();

        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;
        Vector3 hitPoint = playerCam.transform.position + playerCam.transform.forward * range;

        if (Physics.Raycast(ray, out hit, range, shootableLayers))
        {
            hitPoint = hit.point;

            var target = hit.collider.GetComponent<Target>();
            if (target != null)
                target.Hit();

            if (hitEffectManager != null)
                hitEffectManager.SpawnHitEffect(hit);

            if (hit.collider.CompareTag("DestroyableTag"))
            {
                destroyableSoundSpawner?.PlaySoundAt(hit.point);
                hitEffectManager?.SpawnDestructionEffect(hit.point, hit.normal);
                Destroy(hit.collider.gameObject);
            }
        }

        SpawnBulletTrail(muzzlePoint.position, hitPoint);

        if (currentAmmo == 0)
            Reload();
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);
    }

    private void SpawnBulletTrail(Vector3 start, Vector3 end)
    {
        if (bulletTrailPrefab == null) return;

        GameObject trail = Instantiate(bulletTrailPrefab, start, Quaternion.identity);
        LineRenderer lr = trail.GetComponent<LineRenderer>();

        if (lr)
        {
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
        }

        Destroy(trail, 0.2f);
    }
}
