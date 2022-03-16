using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float starthealth = 100;
    public GameObject deathEffect;
    public Image healthBar;
    public int value = 25;

    private float health;

    void Start()
    {
        health = starthealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / starthealth;

        if (health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Points += value;
        Destroy(gameObject);
    }
}
