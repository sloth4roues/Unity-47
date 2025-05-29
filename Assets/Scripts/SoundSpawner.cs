using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 1f;

    public void PlaySoundAt(Vector3 position)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = position;

        AudioSource aSource = tempGO.AddComponent<AudioSource>();
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.Play();

        Destroy(tempGO, clip.length);
    }
}
