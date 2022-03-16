using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsUI : MonoBehaviour
{
    public Text pointsText;

    void Update()
    {
        pointsText.text = "Points: " + PlayerStats.Points.ToString();
    }
}
