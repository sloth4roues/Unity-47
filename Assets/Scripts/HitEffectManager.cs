using UnityEngine;

public class HitEffectManager : MonoBehaviour
{
    public GameObject targetHitEffect;
    public GameObject craftHitEffect;

    public LayerMask hitLayer;
    public LayerMask craftLayer;

    public GameObject destructionEffect;

    public void SpawnHitEffect(RaycastHit hit)
    {

        GameObject effectToSpawn = null;

        int hitObjectLayer = hit.collider.gameObject.layer;
        int hitLayerMask = 1 << hitObjectLayer;

        if ((hitLayerMask & hitLayer) != 0)
        {
            effectToSpawn = targetHitEffect;
        }
        else if ((hitLayerMask & craftLayer) != 0)
        {
            effectToSpawn = craftHitEffect;
        }

        if (effectToSpawn != null)
        {
            GameObject spawned = Instantiate(effectToSpawn, hit.point, Quaternion.LookRotation(hit.normal));
            spawned.transform.SetParent(null);
            Destroy(spawned, 1.5f);
        }
    }
    public void SpawnDestructionEffect(Vector3 position, Vector3 normal)
    {
        if (destructionEffect != null)
        {
            GameObject spawned = Instantiate(destructionEffect, position, Quaternion.LookRotation(normal));
            spawned.transform.SetParent(null);
            Destroy(spawned, 2f);
        }
    }

}
