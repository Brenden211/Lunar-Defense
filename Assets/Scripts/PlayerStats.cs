using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Points;
    public static int damageTake = 2;
    public int startingPoints = 300;
    public static int Rounds;
    public Image PlayerHealthBar;
    public float playerStartingHP = 10f;
    public static float playerHP;


    void Start()
    {
        Points = startingPoints;
        Rounds = 0;
        playerHP = playerStartingHP;
        PlayerHealthBar.fillAmount = playerHP;
    }

    public void PlayerTakeDamage(float amount)
    {
        playerHP -= amount;

        PlayerHealthBar.fillAmount = playerHP / playerStartingHP;


        if (playerHP == 0)
        {
            Debug.Log("Player Has Lost!");
        }
        else
        {
            return;
        }
    }
}
