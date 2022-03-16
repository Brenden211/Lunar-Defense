using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject basicTurretPrefab;
    public GameObject heavyTurretPrefab;
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    void Awake()
    {
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasPoints { get { return PlayerStats.Points >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Points < turretToBuild.cost)
        {
            Debug.Log("Not Enough Points");
            return;
        }

        PlayerStats.Points -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret Built");
    }
}
