using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempNode : MonoBehaviour {
    public Vector3 positionOffset;
    private GameObject turretPrefab;
    private GameObject turret;

    private void Start()
    {
        turretPrefab = (GameObject)Resources.Load("Turret 1", typeof(GameObject));
    }

    public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	//void BuildTurret (TurretBlueprint blueprint)
	public void BuildTurret ()
	{
        /*
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
        */

		GameObject newTurret = (GameObject)Instantiate(turretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = newTurret;

		Debug.Log("Turret build!");
	}
}
