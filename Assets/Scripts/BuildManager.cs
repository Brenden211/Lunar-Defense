using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject basicTurretPrefab;

    private GameObject turretToBuild;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        turretToBuild = basicTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
