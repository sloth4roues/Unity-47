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

    private PlayerInput input;
    private InputAction fireAction;

    public static event Action<int, int> OnAmmoChanged;

    private UIManager uiManager;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        uiManager = FindObjectOfType<UIManager>();
        uiManager?.UpdateAmmo(currentAmmo, maxAmmo);
    }

    private void OnEnable()
    {
        if (input?.actions != null)
        {
            fireAction = input.actions["Fire"];
            fireAction.performed += Fire;
            fireAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (fireAction != null)
            fireAction.performed -= Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed || currentAmmo <= 0)
            return;

        if (GameSession.Instance != null && GameSession.Instance.gameEnded)
            return;

        Shoot();
    }

    private void Shoot()
    {
        currentAmmo--;
        OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);

        muzzleFlash?.Play();
        shootSound?.Play();

        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        Vector3 hitPoint = ray.origin + ray.direction * range;

        if (Physics.Raycast(ray, out RaycastHit hit, range, shootableLayers))
        {
            hitPoint = hit.point;

            hit.collider.GetComponent<Target>()?.Hit();
            hitEffectManager?.SpawnHitEffect(hit);

            if (hit.collider.CompareTag("DestroyableTag"))
            {
                destroyableSoundSpawner?.PlaySoundAt(hit.point);
                hitEffectManager?.SpawnDestructionEffect(hit.point, hit.normal);
                Destroy(hit.collider.gameObject);
            }
        }

        SpawnBulletTrail(muzzlePoint.position, hitPoint);
    }

    public void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            OnAmmoChanged?.Invoke(currentAmmo, maxAmmo);
        }
    }

    private void SpawnBulletTrail(Vector3 start, Vector3 end)
    {
        if (bulletTrailPrefab == null) return;

        GameObject trail = Instantiate(bulletTrailPrefab, start, Quaternion.identity);
        if (trail.TryGetComponent(out LineRenderer lr))
        {
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
        }
        Destroy(trail, 0.2f);
    }
}
