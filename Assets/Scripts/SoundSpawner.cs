using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public GameObject soundPrefab; 

    public void PlaySoundAt(Vector3 position)
    {
        if (soundPrefab == null)
        {
            Debug.LogWarning("SoundPrefab non assigné !");
            return;
        }

        GameObject spawned = Instantiate(soundPrefab, position, Quaternion.identity);
        AudioSource source = spawned.GetComponent<AudioSource>();

        if (source != null)
        {
            source.Play();
            Destroy(spawned, source.clip.length);
        }
        else
        {
            Destroy(spawned);
        }
    }
}
