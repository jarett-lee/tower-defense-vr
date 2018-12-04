using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;
    public Material highlightMaterial;

	private Renderer rend;
    private Material startMaterial;

	BuildManager buildManager;

	void Start ()
	{
        rend = GetComponentInChildren<Renderer>();
        startMaterial = rend.material;
		buildManager = BuildManager.instance;
        //Highlight();
    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	public void Select ()
    {
		buildManager.SelectNode(this);
    }

	public void Highlight ()
    {
        rend.material = highlightMaterial;
    }

	public void UnHighlight ()
    {
        rend.material = startMaterial;
    }

	public void AttemptBuildTurret ()
	{
		if (turret != null)
		{
            Debug.Log("select turret");
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

        // TODO do better sound
        GameObject soundGameObject = new GameObject();
        soundGameObject.transform.position = turret.transform.position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Sound/Hammer") as AudioClip;
        audioSource.Play();
        Destroy(soundGameObject, 5f);

		Debug.Log("Turret built!");
	}

	public void UpgradeTurret ()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Get rid of the old turret
		Destroy(turret);

		//Build a new one
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		isUpgraded = true;

		Debug.Log("Turret upgraded!");
	}

	public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

        // TODO do better sound
        GameObject soundGameObject = new GameObject();
        soundGameObject.transform.position = turret.transform.position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Sound/Cha Ching") as AudioClip;
        audioSource.Play();
        Destroy(soundGameObject, 5f);

		Destroy(turret);
		turret = null;
		turretBlueprint = null;
        isUpgraded = false;
	}
}
