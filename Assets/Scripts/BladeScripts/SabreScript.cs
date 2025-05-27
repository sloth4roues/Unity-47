using UnityEngine;

public class SabreScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter(Collider col)
    {
        EnnemiesScript enemy = col.gameObject.GetComponent<EnnemiesScript>();
        if (enemy != null)
        {
            enemy.RemoveLife(35);
        }
    }
}
