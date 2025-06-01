using System;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public static event Action<int, int> OnHPChanged;

    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
        OnHPChanged?.Invoke(currentHP, maxHP);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }



    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        OnHPChanged?.Invoke(currentHP, maxHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort.");
    }

}
