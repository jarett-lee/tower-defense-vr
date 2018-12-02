using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour {
	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void UpgradeTurret ()
	{
		Debug.Log("Upgrade Turret");
        buildManager.UpgradeTurret();
	}

	public void SellTurret ()
	{
		Debug.Log("Sell Turret");
        buildManager.SellTurret();
	}
}
