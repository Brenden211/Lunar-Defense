using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Points;
    public int startingPoints = 300;

    void Start()
    {
        Points = startingPoints;
    }
}
