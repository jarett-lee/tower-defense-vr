using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text turret1Text;
    public Text turret2Text;
    public Text turret3Text;

    public TurretBlueprint turretBlueprint1;
    public TurretBlueprint turretBlueprint2;
    public TurretBlueprint turretBlueprint3;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        turret1Text.text = "Buy turret 1 for $" + turretBlueprint1.cost;
        turret2Text.text = "Buy turret 2 for $" + turretBlueprint2.cost;
        turret3Text.text = "Buy turret 3 for $" + turretBlueprint3.cost;
    }

    public void SelectTurret1()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(turretBlueprint1);
    }

    public void SelectTurret2()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(turretBlueprint2);
    }

    public void SelectTurret3()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(turretBlueprint3);
    }

}
