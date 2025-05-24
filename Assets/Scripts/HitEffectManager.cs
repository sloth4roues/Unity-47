using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public GameObject targetHitEffect;
    public GameObject defaultHitEffect;

    public LayerMask hitLayer;
    public LayerMask craftLayer;

    public void SpawnHitEffect(RaycastHit hit)
    {
        GameObject effectToSpawn = null;

        if (((1 << hit.collider.gameObject.layer) & hitLayer) != 0)
        {
            effectToSpawn = targetHitEffect;
        }
        else if (((1 << hit.collider.gameObject.layer) & craftLayer) != 0)
        {
            effectToSpawn = defaultHitEffect;
        }

        if (effectToSpawn != null)
        {
            GameObject spawned = Instantiate(effectToSpawn, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(spawned, 1.5f);
        }
    }
}
