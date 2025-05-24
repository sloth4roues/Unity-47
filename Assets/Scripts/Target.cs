using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject hitSoundPrefab;

    public void Hit()
    {
        if (hitSoundPrefab)
            Instantiate(hitSoundPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}