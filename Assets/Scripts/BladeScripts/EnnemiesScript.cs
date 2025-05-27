using UnityEngine;
using UnityEngine.AI;

public class EnnemiesScript : MonoBehaviour
{
    public int life = 100;
    public Transform target;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void RemoveLife(int value)
    {
        life -= value;
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}