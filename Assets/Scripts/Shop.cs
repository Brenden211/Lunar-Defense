using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint basicTurret;
    public TurretBlueprint heavyTurret;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectedBasicTurret()
    {
        Debug.Log("Basic Turret Selected");
        buildManager.SelectTurretToBuild(basicTurret);
    }

    public void SelectedHeavyTurret()
    {
        Debug.Log("Heavy Turret Selected");
        buildManager.SelectTurretToBuild(heavyTurret);
    }
}
