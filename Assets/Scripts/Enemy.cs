using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public int worth = 25;
    public GameObject deathEffect;
    public Image healthBar;
    public float startHealth = 100;

    void Start()
    {
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Dead!");
        Destroy(gameObject);
    }
}
